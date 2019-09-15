using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MotionAnalyzer2 {
    public partial class ControllerForm : Form, IChildForm {
        public ControllerForm() {
            InitializeComponent();

            tabPageSelect.Tag = AnalyzeDirector.TabMode.Select;
            tabPageCondition.Tag = AnalyzeDirector.TabMode.Condition;
            tabPageGraph.Tag = AnalyzeDirector.TabMode.Graph;
            tabPageAggregate.Tag = AnalyzeDirector.TabMode.Aggregate;

            List<ShapeItem> src = new List<ShapeItem>() {
                new ShapeItem { Name = "円", Shape = Parameters.TargetShape.Circle },
                new ShapeItem { Name = "長方形", Shape = Parameters.TargetShape.Rectangle },
                new ShapeItem { Name = "任意", Shape = Parameters.TargetShape.Any },
            };
            comboBoxShape.DisplayMember = "Name";
            comboBoxShape.ValueMember = "Shape";
            comboBoxShape.DataSource = src;
            comboBoxShape.SelectedValue = Parameters.TargetShape.Any;

            listView.BeginUpdate();
            listView.Items.Clear();
            foreach (string file in Settings.VideoFiles) {
                Bitmap thumb = VideoImaging.GetThumbnail(file, imageList.ImageSize);
                if (thumb != null) {
                    imageList.Images.Add(thumb);
                    ListViewItem item = new ListViewItem() {
                        Name = file,
                        ImageIndex = imageList.Images.Count - 1,
                    };
                    listView.Items.Add(item);
                }
            }
            listView.EndUpdate();

            comboBoxViewMode.SelectedIndex = 0;
        }

        private void EnableTab(TabPage page, bool enabled) {
            if (enabled) {
                if (!tabControl.TabPages.Contains(page)) {
                    tabControl.TabPages.Add(page);
                }
            }
            else {
                if (tabControl.TabPages.Contains(page)) {
                    tabControl.TabPages.Remove(page);
                }
            }
        }
        public void SwitchTab() {
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }

        public void UpdateCtrl() {
            EnableTab(tabPageCondition, AnalyzeDirector.VideoImaging != null);
            EnableTab(tabPageGraph, AnalyzeDirector.MotionData != null);
            listView.View = comboBoxViewMode.SelectedIndex == 0 ? View.LargeIcon : View.List;

            listBoxAggregate.Items.Clear();
            foreach(ListViewItem item in listView.Items) {
                string file = item.Name;
                string c1 = File.Exists(Settings.XmlFilename(file)) ? "@" : " ";
                string c2 = File.Exists(Settings.RawDataname(file)) ? "#" : " ";
                item.Text = $"[{c1}{c2}] {file}";

                if (File.Exists(Settings.RawDataname(file))) {
                    listBoxAggregate.Items.Add(file);
                }
            }
            
            if (AnalyzeDirector.VideoImaging != null) {
                Parameters para = AnalyzeDirector.Parameters;
                var tc = para.TargetColor;

                textBoxFrameCount.Text = AnalyzeDirector.VideoImaging.FrameCount.ToString();
                textBoxFPS.Text = para.FPS.ToString();
                textBoxRuler.Text = para.RulerLength.ToString();
                textBoxSFrame.Text = para.StartFrame.ToString();
                textBoxEFrame.Text = para.EndFrame.ToString();
                numericBinary.Value = para.Thresh;
                pictureBoxTarget.BackColor = Color.FromArgb(tc.Item2, tc.Item1, tc.Item0);
                comboBoxShape.SelectedValue = para.Shape;
                checkBoxAngle.Checked = para.DetectAngle;
                numericUpDownWindow.Value = (decimal)para.LSWindow;
                numericUpDownStorobo.Value = para.StoroboStep;
                numericUpDownXaxis.Value = para.XaxisAngle;
                checkBoxRevYaxis.Checked = para.ReverseYaxis;
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e) {
            AnalyzeDirector.LoadVideoBtnClick(listView.SelectedItems[0].Name);
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e) {
            buttonLoad.Enabled = listView.SelectedItems.Count != 0;
        }

        private void ButtonSFrame_Click(object sender, EventArgs e) {
            AnalyzeDirector.Parameters.StartFrame = AnalyzeDirector.VideoImaging.PosFrames;
            AnalyzeDirector.UpdateAllControll();
        }

        private void ButtonEFrame_Click(object sender, EventArgs e) {
            AnalyzeDirector.Parameters.EndFrame = AnalyzeDirector.VideoImaging.PosFrames;
            AnalyzeDirector.UpdateAllControll();
        }

        private void NumericBinary_ValueChanged(object sender, EventArgs e) {
            AnalyzeDirector.Parameters.Thresh = (int)numericBinary.Value;
            AnalyzeDirector.UpdateAllControll();
        }

        private void ComboBoxShape_SelectedIndexChanged(object sender, EventArgs e) {
            checkBoxAngle.Enabled = (Parameters.TargetShape)comboBoxShape.SelectedValue != Parameters.TargetShape.Circle;
            if (AnalyzeDirector.Loaded) {
                AnalyzeDirector.Parameters.Shape = (Parameters.TargetShape)comboBoxShape.SelectedValue;
                AnalyzeDirector.UpdateAllControll();
            }
        }

        private void CheckBoxAngle_CheckedChanged(object sender, EventArgs e) {
            if (AnalyzeDirector.Loaded) {
                AnalyzeDirector.Parameters.DetectAngle = checkBoxAngle.Checked;
                AnalyzeDirector.UpdateAllControll();
            }
        }

        private void ButtonAnalyze_Click(object sender, EventArgs e) {
            if (AnalyzeDirector.Loaded) {
                AnalyzeDirector.AnalyzeAllBtnClick();
            }
        }

        private void ButtonSaveSetting_Click(object sender, EventArgs e) {
            if (AnalyzeDirector.Loaded) {
                AnalyzeDirector.Parameters.Save();
            }
        }

        private void ComboBoxViewMode_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateCtrl();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e) {
            AnalyzeDirector.Tab = (AnalyzeDirector.TabMode)tabControl.SelectedTab.Tag;
            AnalyzeDirector.UpdateAllControll();
        }

        private void ListBoxAggregate_SelectedIndexChanged(object sender, EventArgs e) {
            var list = listBoxAggregate.SelectedItems.Cast<string>();
            AnalyzeDirector.AggregateListChanged(list);
        }

        private void ButtonAggregate_Click(object sender, EventArgs e) {
            AnalyzeDirector.SaveAggregateData();
        }
        private void GraphCtrlValueChanged(object sender, EventArgs e) {
            if (AnalyzeDirector.Loaded) {
                AnalyzeDirector.Parameters.StoroboStep = (int)numericUpDownStorobo.Value;
                AnalyzeDirector.Parameters.LSWindow = (double)numericUpDownWindow.Value;
                AnalyzeDirector.Parameters.XaxisAngle = (int)numericUpDownXaxis.Value;
                AnalyzeDirector.Parameters.ReverseYaxis = checkBoxRevYaxis.Checked;
                AnalyzeDirector.UpdateAllControll();
            }
        }

    }

    public class ShapeItem {
        public String Name { get; set; }
        public Parameters.TargetShape Shape { get; set; }
    }
}
