using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MotionAnalyzer2 {
    public struct TXYW {
        public double t, x, y, w;
        public static string Caption {
            get { return string.Format("#{0}, {1}, {2}, {3,10}", "time", "x", "y", "angle"); }
        }
        public override string ToString() {
            return string.Format("{0:f10}, {1:f10}, {2:f10}, {3:f10}", t, x, y, w);
        }
        public string ToRichString(bool detectAngle) {
            string str = string.Format("t={0:f0}", t);
            //str += string.Format("    x={0:f2}    y={1:f2}", x, y);
            //if (detectAngle) str += string.Format("    w={0:f2} rad", w);
            return str;
        }
        public static TXYW FromStr(string line) {
            var txyw = line.Split(',').Select(double.Parse).ToArray();
            return new TXYW() { t = txyw[0], x = txyw[1], y = txyw[2], w = txyw[3] };
        }
    }

    public class MotionData {
        double Tw(double d) => d * d;

        public enum Column { T = 0, X = 1, Y = 2, W = 3, VX = 4, VY = 5, VW = 6, AX = 7, AY = 8, AW = 9 }
        public static readonly string[] ColumnStr = {
            "時間 [s]",
            "位置のx成分 [m]",
            "位置のy成分 [m]",
            "角度 [rad]",
            "速度のx成分 [m/s]",
            "速度のy成分 [m/s]",
            "角速度 [rad/s]",
            "加速度のx成分 [m/s2]",
            "加速度のy成分 [m/s2]",
            "角加速度 [rad/s2]" };

        public Parameters parameters;
        public List<TXYW> RawData;
        public double[][] PlotData;
        public double[] Min;
        public double[] Max;

        public static MotionData TryLoadRawData(string videoFile, Parameters parameters) {
            
            string file = Settings.RawDataname(videoFile);
            if (File.Exists(file)) {
                MotionData md = new MotionData();
                md.parameters = parameters;
                using (var sr = new StreamReader(file)) {
                    sr.ReadLine();
                    while (!sr.EndOfStream) md.AddRawData(TXYW.FromStr(sr.ReadLine()));
                }
                return md;
            }
            else {
                return null;
            }
        }

        public MotionData() {
            RawData = new List<TXYW>();
            int N = Enum.GetNames(typeof(Column)).Length;
            PlotData = new double[N][];
            Min = new double[N];
            Max = new double[N];

            for (int c = 0; c < PlotData.Length; c++) PlotData[c] = new double[0];
            parameters = AnalyzeDirector.Parameters;
        }


        public void AddRawData(TXYW txyw) {
            if (RawData.Count != 0) {
                double preW = RawData.Last().w;
                while (txyw.w - preW > Math.PI) txyw.w -= Math.PI;
                while (txyw.w - preW < -Math.PI) txyw.w += Math.PI;
            }
            RawData.Add(txyw);
        }

        public void SaveRawData(string videoFile) {
            string file = Settings.RawDataname(videoFile);
            using (var sw = new StreamWriter(file, false)) {
                sw.WriteLine(TXYW.Caption);
                foreach (TXYW txyw in RawData) {
                    sw.WriteLine(txyw);
                }
            }
        }
        public void SavePlotData(string videoFile) {
            string file = Settings.PlotDataname(videoFile);
            using (var sw = new StreamWriter(file, false)) {
                foreach (string str in ColumnStr) sw.Write("#" + str + ",");
                sw.WriteLine();

                for (int i = 0; i < PlotData[0].Length; i++) {
                    for (int c = 0; c < PlotData.Length; c++) {
                        sw.Write(PlotData[c][i].ToString("F10") + ",");
                    }
                    sw.WriteLine();
                }
            }
        }

        public OpenCvSharp.Point GetOrigin() {
            TXYW ini = RawData[0];
            return new OpenCvSharp.Point(ini.x, ini.y);
        }

        public void UpdatePlotData() {
            double spf = 1d / parameters.FPS;
            double width = parameters.LSWindow * spf;
            double theta = parameters.XaxisAngle / 180d * Math.PI;
            double rularDia = parameters.RularDia() ?? 1;
            double cos = Math.Cos(theta);
            double sin = Math.Sin(theta);

            int revY = parameters.ReverseYaxis ? 1 : -1;
            int N = RawData.Count;
            for (int c = 0; c < PlotData.Length; c++) {
                if (PlotData[c].Length != N) PlotData[c] = new double[N];
            }

            //offset and rotate
            TXYW ini = RawData[0];
            for (int i = 0; i < RawData.Count; i++) {
                double x0 = RawData[i].x - ini.x;
                double y0 = RawData[i].y - ini.y;

                PlotData[0][i] = (RawData[i].t - ini.t)* spf;
                PlotData[1][i] = (x0 * cos + y0 * sin)* rularDia;
                PlotData[2][i] = (-x0 * sin + y0 * cos) * revY* rularDia;
                PlotData[3][i] = (RawData[i].w - ini.w - theta) * revY;
            }

            //least square
            for (int i = 0; i < N; i++) {
                double ti = PlotData[0][i];
                for (int c = 1; c <= 3; c++) {
                    double t0 = 0, t1 = 0, t2 = 0, t3 = 0, t4 = 0;
                    double x0 = 0, x1 = 0, x2 = 0;
                    for (int j = 0; j < N; j++) {
                        double t = PlotData[0][j];
                        double x = PlotData[c][j];
                        double w = Math.Exp(-0.5 * Tw((ti - t) / width));
                        double tt = t * t;
                        t0 += w;
                        t1 += w * t;
                        t2 += w * tt;
                        t3 += w * tt * t;
                        t4 += w * tt * tt;
                        x0 += w * x;
                        x1 += w * x * t;
                        x2 += w * x * tt;
                    }
                    double D = (t4 * t0 - t2 * t2) * (t2 * t0 - t1 * t1) - Tw(t3 * t0 - t2 * t1);
                    double A = ((x2 * t0 - x0 * t2) * (t2 * t0 - t1 * t1) - (x1 * t0 - x0 * t1) * (t3 * t0 - t2 * t1)) / D;
                    double B = ((x1 * t0 - x0 * t1) * (t4 * t0 - t2 * t2) - (x2 * t0 - x0 * t2) * (t3 * t0 - t2 * t1)) / D;
                    PlotData[c + 3][i] = B + 2 * A * ti;
                    PlotData[c + 6][i] = 2 * A;
                }
            }

            //minmax
            for (int c = 0; c < PlotData.Length; c++) {
                Max[c] = PlotData[c].Max();
                Min[c] = PlotData[c].Min();
            }

            SavePlotData(parameters.VideoFile);
        }
    }
}