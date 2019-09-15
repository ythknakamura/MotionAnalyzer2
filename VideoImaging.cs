using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OPoint = OpenCvSharp.Point;
using OSize = OpenCvSharp.Size;
namespace MotionAnalyzer2 {
    public class VideoImaging {
        private readonly string path;

        Mat rawmat, rMask, cMask, binary;
        Mat output3;
        bool rawmatSet, rMaksSet, cMaskSet, binarySet;
        readonly VideoCapture videoCapture;

        public static System.Drawing.Bitmap GetThumbnail(string videoFile, System.Drawing.Size size) {
            string path = Settings.VideoFullPath(videoFile);
            VideoImaging vi = new VideoImaging(path);
            if (vi != null) {
                vi.PosFrames = vi.videoCapture.FrameCount / 2;
                vi.SetRawMat();
                Mat mat = vi.rawmat;
                mat = mat.Resize(new Size(size.Width,size.Height));
                vi.videoCapture.Dispose();
                return BitmapConverter.ToBitmap(mat);
            }
            else {
                return null;
            }
        }

        public static VideoImaging Load(string videoFile) {
            string path = Settings.VideoFullPath(videoFile);
            VideoImaging vi = new VideoImaging(path);
            return vi.videoCapture.IsOpened() ? vi : null;
        }

        VideoImaging(string path) {
            this.path = path;
            videoCapture = new VideoCapture(path);
            OpenCvSharp.Size size = new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight);
            rawmat = new Mat(size, MatType.CV_8UC3);
            rMask = new Mat(size, MatType.CV_8UC1);
            cMask = new Mat(size, MatType.CV_8UC1);
            binary = new Mat(size, MatType.CV_8UC1);
            output3 = new Mat(size, MatType.CV_8UC3);
            ResetFlags();
        }
        ~VideoImaging() {
            if (!videoCapture.IsDisposed) videoCapture.Dispose();
        }

        public int PosFrames {
            get { return videoCapture.PosFrames; }
            set {
                int frame = value;
                frame = Math.Max(frame, 0);
                frame = Math.Min(frame, videoCapture.FrameCount - 1);
                videoCapture.PosFrames = frame;
                ResetFlags();
            }
        }
        public int FrameCount {
            get { return videoCapture.FrameCount; }
        }
        public double FPS {
            get { return videoCapture.Fps; }
        }
        public OSize Size {
            get { return new OSize(videoCapture.FrameWidth, videoCapture.FrameHeight); }
        }

        public Mat GetRawMat() {
            SetRawMat();
            return rawmat;
        }

        public Mat RangeMaskedMat(Parameters para) {
            SetRawMat();
            SetRangeMask(para);
            rawmat.CopyTo(output3);
            output3 *= 0.5;
            rawmat.CopyTo(output3, rMask);
            return output3;
        }

        public Mat BinaryMat(Parameters para) {
            SetBinary(para);
            return binary;
        }

        public Mat DetectedMat(Parameters para) {
            var contour = GetContour(para);
            if (contour != null) {
                DrawToOutput(contour, para);
                return output3;
            }
            else {
                return null;
            }
        }

        public Mat StoroboMat(Parameters para) {
            int step = para.StoroboStep;
            using (Mat mask = new Mat(rawmat.Size(), MatType.CV_8UC1, Scalar.Black)) {
                SetRawMat();
                rawmat.CopyTo(output3);
                for (int t = para.StartFrame; t < para.EndFrame; t += step) {
                    PosFrames = t;
                    var cnt = new List<IEnumerable<OPoint>> { GetContour(para) };
                    if (cnt[0] == null) continue;
                    SetRawMat();
                    mask.SetTo(Scalar.Black);
                    Cv2.DrawContours(mask, cnt, 0, Scalar.White, -1);
                    rawmat.CopyTo(output3, mask);
                    double phase = (t - para.StartFrame) / (double)(para.EndFrame - para.StartFrame);
                    Cv2.DrawContours(output3, cnt, 0, Rainbow(phase), 4);
                }
            }
            return output3;
        }
        public Mat TrajectoryMat(Parameters para) {
            SetRawMat();
            rawmat.CopyTo(output3);
            double dia = para.RularDia() ?? 1d;
            var points = AnalyzeDirector.MotionData.RawData
                .Select(twxt => new OPoint(twxt.x / dia, twxt.y / dia)).ToArray();
            for (int i = 0; i < points.Length - 1; i++) {
                double phase = (double)i / points.Length;
                Cv2.Line(output3, points[i], points[i + 1], Rainbow(phase), 5);
            }
            return output3;
        }

        public MotionData AnalizeAll(Parameters para) {
            string targetDir = Settings.TargetDir(para.VideoFile);
            MotionData md = new MotionData();
            VideoWriter writer = new VideoWriter(Settings.DetectVideoname(para.VideoFile),
                FourCC.MPG4, 30, output3.Size());

            Action<object, DoWorkEventArgs> ProgressDialogDoWork = (sender, e) => {
                var bw = sender as BackgroundWorker;
                int num = para.EndFrame - para.StartFrame + 1;
                for (int t = para.StartFrame; t < para.EndFrame; t++) {
                    PosFrames = t;
                    var contour = GetContour(para);
                    if (contour != null) {
                        TXYW txyw = DrawToOutput(contour, para);
                        md.AddRawData(txyw);
                    }
                    //output3.SaveImage(Path.Combine(targetDir, "out" + t.ToString("00000") + ".jpg"));
                    writer.Write(output3);
                    if (bw.CancellationPending) {
                        e.Cancel = true;
                        break;
                    }
                    string message = string.Format("{0}/{1}", t-para.StartFrame, num);
                    bw.ReportProgress((int)((t-para.StartFrame) * 100 / num), message);
                }
                md.UpdatePlotData();
            };

            ProgressDialog pd = new ProgressDialog("解析中", new DoWorkEventHandler(ProgressDialogDoWork));
            DialogResult result = pd.ShowDialog();

            writer.Release();
            writer.Dispose();
            pd.Dispose();
            return result == DialogResult.OK ? md : null;
        }

        private void ResetFlags() {
            rawmatSet = false;
            rMaksSet = false;
            cMaskSet = false;
            binarySet = false;
        }

        private void SetRawMat() {
            if (rawmatSet) return;
            ResetFlags();
            int f = PosFrames;
            videoCapture.Read(rawmat);
            PosFrames = f;
            rawmatSet = true;

            if (rawmat.Empty()) {
                OpenCvSharp.Size size = new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight);
                rawmat = new Mat(size, MatType.CV_8UC3);
            }
        }

        private void SetRangeMask(Parameters para) {
            if (rMaksSet) return;

            var points = para.Range;
            if (points.Count >= 3) {
                var opoints = points.Select(po => new OPoint(po.X, po.Y));
                rMask.SetTo(Scalar.Black);
                rMask.FillPoly(new IEnumerable<OPoint>[] { opoints }, Scalar.White);
            }
            else {
                rMask.SetTo(Scalar.White);
            }
            rMaksSet = true;
        }

        private void SetColorMask(Parameters para) {
            if (cMaskSet) return;
            if (!rawmatSet) SetRawMat();
            Vec3b c = para.TargetColor;
            int t = para.Thresh;
            Scalar lower = new Scalar(c.Item0 - t, c.Item1 - t, c.Item2 - t);
            Scalar upper = new Scalar(c.Item0 + t, c.Item1 + t, c.Item2 + t);
            Cv2.InRange(rawmat, lower, upper, cMask);
            cMaskSet = true;
        }

        private void SetBinary(Parameters para) {
            if (binarySet) return;
            if (!rMaksSet) SetRangeMask(para);
            if (!cMaskSet) SetColorMask(para);
            Cv2.BitwiseAnd(cMask, rMask, binary);
            binarySet = true;
        }

        private IEnumerable<OPoint> GetContour(Parameters para) {
            SetBinary(para);

            Cv2.FindContours(binary, out OPoint[][] contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            if (contours.Length > 0) {
                int index = 0;
                double maxA = -1;
                for (int i = 0; i < contours.Length; i++) {
                    double a = Cv2.ContourArea(contours[i]);
                    if (a > maxA) {
                        maxA = a;
                        index = i;
                    }
                }

                IEnumerable<OPoint> contour = null;
                switch (para.Shape) {
                    case Parameters.TargetShape.Circle:
                        const int DIV = 30;
                        Point2f center;
                        float radius;
                        Cv2.MinEnclosingCircle(contours[index], out center, out radius);
                        contour = Enumerable.Range(0, DIV)
                            .Select(i => 2 * Math.PI * i / DIV)
                            .Select(t => new OPoint(center.X + radius * Math.Cos(t), center.Y + radius * Math.Sin(t)));
                        break;
                    case Parameters.TargetShape.Rectangle:
                        contour = Cv2.MinAreaRect(contours[index]).Points().Select(p => new OPoint(p.X, p.Y));
                        break;
                    case Parameters.TargetShape.Any:
                        contour = contours[index];
                        break;
                }
                return contour;
            }
            else {
                return null;
            }
        }

        private TXYW DrawToOutput(IEnumerable<OPoint> contour, Parameters para) {
            bool detectAngle = para.DetectAngle && (para.Shape != Parameters.TargetShape.Circle);
            rawmat.CopyTo(output3);
            Moments m = Cv2.Moments(contour);
            TXYW txyw = new TXYW();

            output3.DrawContours(new IEnumerable<OPoint>[] { contour }, 0, Scalar.Red, 5);

            double comx = m.M10 / m.M00;
            double comy = m.M01 / m.M00;
            Cv2.Circle(output3, (int)comx, (int)comy, 10, Scalar.Red, -1);

            double time = PosFrames / (double)para.FPS;
            txyw.t = time;

            double rularDia = para.RularDia() ?? 1;
            txyw.x = comx * rularDia;
            txyw.y = comy * rularDia;
            
            if (detectAngle) {
                double angle = 0.5 * Math.Atan2(2 * m.Mu11, m.Mu20 - m.Mu02);
                const double r = 50;
                OPoint arrow = new OPoint(comx + r * Math.Cos(angle), comy + r * Math.Sin(angle));
                Cv2.Line(output3, new OPoint(comx, comy), arrow, Scalar.Red, 5);
                txyw.w = angle;
            }

            Cv2.PutText(output3, txyw.ToRichString(para.RularDia().HasValue, detectAngle),
                new OPoint(20, videoCapture.FrameHeight - 20),
                HersheyFonts.HersheySimplex, 1, Scalar.Red, 3); ;
            return txyw;
        }

        Scalar Rainbow(double phase) {
            phase = Math.Max(Math.Min(phase, 1.0), 0.0); //0から1に
            double pi = Math.PI;
            double b = 255 * (Math.Sin((1.5 * phase + 2.25) * pi) + 1) / 2;
            double g = 255 * (Math.Sin((1.5 * phase + 1.75) * pi) + 1) / 2;
            double r = 255 * (Math.Sin((1.5 * phase + 1.25) * pi) + 1) / 2;
            return new Scalar(b, g, r);
        }
    }
}
