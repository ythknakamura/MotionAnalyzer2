using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Linq;

namespace MotionAnalyzer2 {
    public partial class GraphForm : Form, IChildForm {
        List<MotionData> motions;
        List<GraphItem> graphs;
        bool cursorFix;

        public void UpdateCtrl() {
            bool enable = AnalyzeDirector.Analized;
            if (AnalyzeDirector.Tab == AnalyzeDirector.TabMode.Select) enable = false;
            if (AnalyzeDirector.Tab == AnalyzeDirector.TabMode.Aggregate) enable = true;

            if (enable) {
                this.Enabled = true;
                this.WindowState = FormWindowState.Normal;
                ButtonCursorReset_Click(null, null);
                chart.Series.Clear();
                foreach (var m in motions) {
                    m.UpdatePlotData();
                    GraphItem item = (comboBoxGraph.SelectedItem as GraphItem).Copy(m.parameters.VideoFile);
                    item.Series.Points.DataBindXY(m.PlotData[0], m.PlotData[item.Index]);
                    chart.ChartAreas[0].AxisY.Title = item.Legend;
                    chart.Series.Add(item.Series);

                }
            }
            else {
                this.Enabled = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        public GraphForm() {
            cursorFix = false;
            motions = new List<MotionData>();
            InitializeComponent();
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f3}";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f3}";
            chart.ChartAreas[0].AxisX.Title = MotionData.ColumnStr[(int)MotionData.Column.T];
           
            graphs = new List<GraphItem>() {
                new GraphItem(MotionData.Column.X),
                new GraphItem(MotionData.Column.VX),
                new GraphItem(MotionData.Column.AX),
                new GraphItem(MotionData.Column.Y),
                new GraphItem(MotionData.Column.VY),
                new GraphItem(MotionData.Column.AY),
                new GraphItem(MotionData.Column.W),
                new GraphItem(MotionData.Column.VW),
                new GraphItem(MotionData.Column.AW),
            };
            
            comboBoxGraph.DisplayMember = "Legend";
            comboBoxGraph.ValueMember = "Index";
            comboBoxGraph.DataSource = graphs;
            comboBoxGraph.SelectedIndex = 0;

            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = double.NaN;
        }

        public void LoadData(MotionData motionData) {
            motions.Clear();
            motions.Add(motionData);
            UpdateCtrl();
        }

        public void LoadManyData(IEnumerable<MotionData> motionDatas) {
            motions.Clear();
            motions.AddRange(motionDatas);
            UpdateCtrl();
        }
        public void SaveManyData() {
            saveFileDialogPng.InitialDirectory = Settings.OutputDir;
            saveFileDialogPng.FileName = ((MotionData.Column)(comboBoxGraph.SelectedItem as GraphItem).Index).ToString() + "." + saveFileDialogCSV.DefaultExt;
            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK) {
                string filename = saveFileDialogCSV.FileName;
                using (var sw = new StreamWriter(filename, false, System.Text.Encoding.Default)) {
                    int index = (comboBoxGraph.SelectedItem as GraphItem).Index;
                    string colstr = MotionData.ColumnStr[index];
                    foreach (var m in motions) {
                        sw.Write($"#{m.parameters.VideoFile}:time,");
                        sw.Write($"#{m.parameters.VideoFile}:{colstr},");
                    }
                    sw.WriteLine();

                    int maxTn = Enumerable.Max(motions, m => m.PlotData[index].Length);
                    Func<MotionData, int, int, string> safeGet = 
                        (m, i, tn) => (tn < m.PlotData[i].Length) ? m.PlotData[i][tn].ToString("F10") : "";

                    for (int tn = 0; tn < maxTn; tn++) {
                        foreach (var m in motions) {
                            sw.Write($"{safeGet(m, (int)MotionData.Column.T, tn)},");
                            sw.Write($"{safeGet(m, index, tn)},");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
        private void ComboBoxGraph_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateCtrl();
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            string dir = motions.Count == 1 ? Settings.TargetDir(motions[0].parameters.VideoFile) : Settings.OutputDir;   
            saveFileDialogPng.InitialDirectory = dir;
            saveFileDialogPng.FileName = ((MotionData.Column)(comboBoxGraph.SelectedItem as GraphItem).Index).ToString() + "." + saveFileDialogPng.DefaultExt;
            if (saveFileDialogPng.ShowDialog() == DialogResult.OK) {
                string filename = saveFileDialogPng.FileName;
                chart.SaveImage(filename, ChartImageFormat.Png);
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e) {
            if (!cursorFix) {
                var mp = new System.Drawing.PointF(e.X, e.Y);
                var area = chart.ChartAreas[0];
                area.CursorX.LineWidth = 1;
                area.CursorY.LineWidth = 1;
                area.CursorX.SetCursorPixelPosition(mp, false);
                area.CursorY.SetCursorPixelPosition(mp, false);
                labelCursor.Text = $"({area.CursorX.Position:f4},  {area.CursorY.Position:g4})";
            }
        }

        private void Chart_MouseLeave(object sender, EventArgs e) {
            if (!cursorFix) {
                chart.ChartAreas[0].CursorX.LineWidth = 0;
                chart.ChartAreas[0].CursorY.LineWidth = 0;
                labelCursor.Text = "";
            }
        }

        private void Chart_MouseClick(object sender, MouseEventArgs e) {
            if (cursorFix) Chart_MouseMove(sender, e);
            cursorFix = true;
        }

        private void ButtonCursorReset_Click(object sender, EventArgs e) {
            cursorFix = false;
            Chart_MouseLeave(sender, e);
        }
    }

    public class GraphItem {
        static Random rnd = new Random();
        public String Legend { get; private set; }
        public int Index { get; private set; }
        public Series Series { get; set; }
        public GraphItem(MotionData.Column col, string name = null) {
            Index = (int)col;
            Legend = MotionData.ColumnStr[Index];
            Series = (name == null) ? new Series() : new Series(name);
            Series.ChartType = SeriesChartType.Line;
            Series.BorderWidth = 3;
        }
        public GraphItem Copy(string name) {
            return new GraphItem((MotionData.Column)Index, name);
        }
    }
}