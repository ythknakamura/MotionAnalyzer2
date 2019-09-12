using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Point = OpenCvSharp.Point;


namespace MotionAnalyzer2 {
    [Serializable]
    public class Parameters {
        public enum TargetShape { Circle, Rectangle, Any };
        public string VideoFile { get; set; }
        public int FPS { get; set; }
        public double RulerLength { get; set; } = 1d;
        public List<Point> Ruler { get; set; } = new List<Point>(2);
        public int Thresh { get; set; } = 50;
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public List<Point> Range { get; set; } = new List<Point>();
        public TargetShape Shape { get; set; } = TargetShape.Any;
        public bool DetectAngle { get; set; } = true;
        public double LSWindow { get; set; } = 0.1d;
        public int StoroboStep { get; set; } = 15;


        [XmlIgnore]
        public Vec3b TargetColor { get; set; } = new Vec3b(255, 255, 255);

        [XmlElement(ElementName = "TargetColor")]
        public string TargetColor_XmlSurrogete {
            get {
                Color c = Color.FromArgb(TargetColor.Item2, TargetColor.Item1, TargetColor.Item0);
                return ColorTranslator.ToHtml(c);
            }
            set {
                Color c = ColorTranslator.FromHtml(value);
                TargetColor = new Vec3b(c.B, c.G, c.R);
            }
        }

        public void Save() {
            string filename = Settings.XmlFilename(VideoFile);
            XmlSerializer serializer = new XmlSerializer(typeof(Parameters));
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8)) {
                serializer.Serialize(sw, this);
                sw.Flush();
            }
        }

        public static Parameters LoadOrCreate(string videoFile, VideoImaging vi) {
            Parameters parameter;
            string targetdir = Settings.TargetDir(videoFile);
            string filename = Settings.XmlFilename(videoFile);
            if (!Directory.Exists(targetdir)) Directory.CreateDirectory(targetdir);
            if (File.Exists(filename)) {
                XmlSerializer serializer = new XmlSerializer(typeof(Parameters));
                var xmlSettings = new System.Xml.XmlReaderSettings() { CheckCharacters = false };
                using (var sr = new StreamReader(filename, Encoding.UTF8))
                using (var xmlReader = System.Xml.XmlReader.Create(sr, xmlSettings)) {
                    parameter = (Parameters)serializer.Deserialize(xmlReader);
                }
            }
            else {
                parameter = new Parameters() {
                    VideoFile = videoFile,
                    FPS = (int)Math.Round(vi.FPS),
                    StartFrame = 0,
                    EndFrame = vi.FrameCount - 1,
                };
                parameter.Save();
            }
            
            return parameter;
        }

        public double? RularDia() {
            if (Ruler.Count == 2) {
                int dx = Ruler[0].X - Ruler[1].X;
                int dy = Ruler[0].Y - Ruler[1].Y;
                return RulerLength / Math.Sqrt(dx * dx + dy * dy);
            }
            else {
                return null;
            }
        }
    }
}