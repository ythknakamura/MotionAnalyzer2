using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSize = System.Drawing.Size;

namespace MotionAnalyzer2 {
    public partial class ImageForm : Form, IChildForm {
        public ImageForm() {
            InitializeComponent();
        }

        public void LoadVideo(VideoImaging vi, int startFrame = 0) {
            trackBar.Maximum = vi.FrameCount - 1;
            trackBar.Value = startFrame;

            Size size = vi.Size;
            if (size.Width > size.Height) {//横長
                this.Width = 800 + 18;
                this.Height = 450 + 147;
            }
            else {//縦長
                this.Width = 450 + 18;
                this.Height = 800 + 147;
            }
        }
        public void UpdateCtrl() {
            Parameters para = AnalyzeDirector.Parameters;

            if (!AnalyzeDirector.Loaded || 
                AnalyzeDirector.Tab == AnalyzeDirector.TabMode.Aggregate ||
                AnalyzeDirector.Tab == AnalyzeDirector.TabMode.Select ) {
                labelFrame.Text = "";
                pictureBoxIpl.ImageIpl = null;
                this.Enabled = false;
                this.WindowState = FormWindowState.Minimized;
                radioButtonRaw.Select();
            }
            else {
                VideoImaging vi = AnalyzeDirector.VideoImaging;
                vi.PosFrames = trackBar.Value;
                Mat mat = new Mat();
                const int R = 10;
                if (radioButtonRaw.Checked) {
                    mat = vi.GetRawMat();
                    List<Point> points = para.Ruler;
                    foreach (Point p in points) mat.Circle(p.X, p.Y, R, Scalar.Blue, 4);
                    if (points.Count == 2) mat.Line(points[0], points[1], Scalar.Blue, 4);
                }
                else if (radioButtonRange.Checked) {
                    mat = vi.RangeMaskedMat(para);
                    foreach (Point p in para.Range) mat.Rectangle(new Rect(p.X - R, p.Y - R, 2 * R, 2 * R), Scalar.Green, -1);
                }
                else if (radioButtonBinary.Checked) {
                    mat = vi.BinaryMat(para);
                }
                else if (radioButtonDetect.Checked) {
                    mat = vi.DetectedMat(para);
                }
                else if (radioButtonStrobo.Checked) {
                    mat = vi.StoroboMat(para);
                }
                else if (radioButtonTrajectory.Checked) {
                    mat = vi.TrajectoryMat(para);
                }

                //axis
                if (AnalyzeDirector.Analized && mat.Type()==MatType.CV_8UC3) {
                    Point o = AnalyzeDirector.MotionData.GetOrigin();
                    double theta = -AnalyzeDirector.Parameters.XaxisAngle / 180d * Math.PI;
                    double dx = Math.Cos(theta);
                    double dy = Math.Sin(theta);
                    double l = mat.Height + mat.Width;
                    mat.Line(new Point(o.X - l * dx, o.Y - l * dy), new Point(o.X + l * dx, o.Y + l * dy), Scalar.Violet, 1);
                    mat.Line(new Point(o.X + l * dy, o.Y - l * dx), new Point(o.X - l * dy, o.Y + l*dx), Scalar.Violet, 1) ;
                }

                labelFrame.Text = vi.PosFrames.ToString() + " / " + (vi.FrameCount - 1).ToString();
                pictureBoxIpl.ImageIpl = mat;
                this.Enabled = true;
                this.WindowState = FormWindowState.Normal;
            }

            radioButtonStrobo.Visible = AnalyzeDirector.MotionData != null;
            radioButtonTrajectory.Visible = AnalyzeDirector.MotionData != null;
        }

        private Point GetImagePos(int mouseX, int mouseY) {
            Size imgSize = AnalyzeDirector.VideoImaging.Size;
            DSize ctrSize = pictureBoxIpl.Size;
            float imageScale = Math.Min(ctrSize.Width / (float)imgSize.Width, ctrSize.Height / (float)imgSize.Height);
            float scaledWidth = imgSize.Width * imageScale;
            float scaledHeight = imgSize.Height * imageScale;

            float offX = (ctrSize.Width - scaledWidth) / 2.0f;
            float offY = (ctrSize.Height - scaledHeight) / 2.0f;

            int x = (int)((mouseX - offX) / imageScale);
            if (x < 0) x = 0;
            else if (x >= imgSize.Width) x = imgSize.Width - 1;

            int y = (int)((mouseY - offY) / imageScale);
            if (y < 0) y = 0;
            else if (y >= imgSize.Height) y = imgSize.Height - 1;

            return new Point(x, y);
        }


        private void PictureBox_MouseClick(object sender, MouseEventArgs e) {
            bool needAllUpdate = false;
            if (!AnalyzeDirector.Loaded) return;

            if (!AnalyzeDirector.Analized) {
                Point p = GetImagePos(e.X, e.Y);
                Parameters para = AnalyzeDirector.Parameters;
                if (radioButtonRaw.Checked) {
                    if (e.Button == MouseButtons.Left) {
                        if (para.Ruler.Count == 2) para.Ruler.Clear();
                        para.Ruler.Add(p);
                    }
                    else if (e.Button == MouseButtons.Right) {
                        para.TargetColor = pictureBoxIpl.ImageIpl.At<Vec3b>(p.Y, p.X);
                        needAllUpdate = true;
                    }
                }
                else if (radioButtonRange.Checked) {
                    if (e.Button == MouseButtons.Left) {
                        para.Range.Add(p);
                    }
                    else if (e.Button == MouseButtons.Right) {
                        para.Range.Clear();
                    }
                }
                if (needAllUpdate) AnalyzeDirector.UpdateAllControll();
                else UpdateCtrl();
            }
            else {
                // MessageBox.Show("破棄する？", "", MessageBoxButtons.OK);
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e) {
            UpdateCtrl();
        }

        private void ButtonSaveImage_Click(object sender, EventArgs e) {
            if (!AnalyzeDirector.Loaded) return;
            string modestr = "";
            if (radioButtonRaw.Checked) modestr = "raw";
            else if (radioButtonRange.Checked) modestr = "range";
            else if (radioButtonBinary.Checked) modestr = "binary";
            else if (radioButtonDetect.Checked) modestr = "detected";
            saveFileDialog.InitialDirectory = Settings.TargetDir(AnalyzeDirector.Parameters.VideoFile);
            saveFileDialog.FileName = string.Format("{0}{1:d5}.jpg", modestr, AnalyzeDirector.VideoImaging.PosFrames);
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string filename = saveFileDialog.FileName;
                pictureBoxIpl.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e) {
            if ((sender as RadioButton).Checked) {
                UpdateCtrl();
            }
        }

    }
}
