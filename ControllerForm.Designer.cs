namespace MotionAnalyzer2 {
    partial class ControllerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSelect = new System.Windows.Forms.TabPage();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxViewMode = new System.Windows.Forms.ComboBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tabPageCondition = new System.Windows.Forms.TabPage();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.checkBoxAngle = new System.Windows.Forms.CheckBox();
            this.comboBoxShape = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.pictureBoxTarget = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericBinary = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonEFrame = new System.Windows.Forms.Button();
            this.buttonSFrame = new System.Windows.Forms.Button();
            this.textBoxEFrame = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSFrame = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRuler = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFPS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrameCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.checkBoxRevYaxis = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownXaxis = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStorobo = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownWindow = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageAggregate = new System.Windows.Forms.TabPage();
            this.buttonAggregate = new System.Windows.Forms.Button();
            this.listBoxAggregate = new System.Windows.Forms.ListBox();
            this.tabPageLamp = new System.Windows.Forms.TabPage();
            this.buttonLamp = new System.Windows.Forms.Button();
            this.listBoxLamp = new System.Windows.Forms.ListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl.SuspendLayout();
            this.tabPageSelect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBinary)).BeginInit();
            this.tabPageGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXaxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStorobo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindow)).BeginInit();
            this.tabPageAggregate.SuspendLayout();
            this.tabPageLamp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSelect);
            this.tabControl.Controls.Add(this.tabPageCondition);
            this.tabControl.Controls.Add(this.tabPageGraph);
            this.tabControl.Controls.Add(this.tabPageAggregate);
            this.tabControl.Controls.Add(this.tabPageLamp);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(496, 378);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageSelect
            // 
            this.tabPageSelect.Controls.Add(this.listView);
            this.tabPageSelect.Controls.Add(this.panel1);
            this.tabPageSelect.Location = new System.Drawing.Point(4, 25);
            this.tabPageSelect.Name = "tabPageSelect";
            this.tabPageSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelect.Size = new System.Drawing.Size(488, 349);
            this.tabPageSelect.TabIndex = 0;
            this.tabPageSelect.Text = "動画の選択";
            this.tabPageSelect.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(3, 53);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(482, 293);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(96, 54);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxViewMode);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 50);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxViewMode
            // 
            this.comboBoxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxViewMode.FormattingEnabled = true;
            this.comboBoxViewMode.Items.AddRange(new object[] {
            "サムネ表示",
            "リスト表示"});
            this.comboBoxViewMode.Location = new System.Drawing.Point(343, 13);
            this.comboBoxViewMode.Name = "comboBoxViewMode";
            this.comboBoxViewMode.Size = new System.Drawing.Size(121, 23);
            this.comboBoxViewMode.TabIndex = 2;
            this.comboBoxViewMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxViewMode_SelectedIndexChanged);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Enabled = false;
            this.buttonLoad.Location = new System.Drawing.Point(3, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 40);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "読み込み";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // tabPageCondition
            // 
            this.tabPageCondition.Controls.Add(this.buttonSaveSetting);
            this.tabPageCondition.Controls.Add(this.checkBoxAngle);
            this.tabPageCondition.Controls.Add(this.comboBoxShape);
            this.tabPageCondition.Controls.Add(this.label9);
            this.tabPageCondition.Controls.Add(this.buttonAnalyze);
            this.tabPageCondition.Controls.Add(this.pictureBoxTarget);
            this.tabPageCondition.Controls.Add(this.label8);
            this.tabPageCondition.Controls.Add(this.numericBinary);
            this.tabPageCondition.Controls.Add(this.label7);
            this.tabPageCondition.Controls.Add(this.buttonEFrame);
            this.tabPageCondition.Controls.Add(this.buttonSFrame);
            this.tabPageCondition.Controls.Add(this.textBoxEFrame);
            this.tabPageCondition.Controls.Add(this.label6);
            this.tabPageCondition.Controls.Add(this.textBoxSFrame);
            this.tabPageCondition.Controls.Add(this.label3);
            this.tabPageCondition.Controls.Add(this.label5);
            this.tabPageCondition.Controls.Add(this.textBoxRuler);
            this.tabPageCondition.Controls.Add(this.label4);
            this.tabPageCondition.Controls.Add(this.textBoxFPS);
            this.tabPageCondition.Controls.Add(this.label2);
            this.tabPageCondition.Controls.Add(this.textBoxFrameCount);
            this.tabPageCondition.Controls.Add(this.label1);
            this.tabPageCondition.Location = new System.Drawing.Point(4, 25);
            this.tabPageCondition.Name = "tabPageCondition";
            this.tabPageCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCondition.Size = new System.Drawing.Size(488, 349);
            this.tabPageCondition.TabIndex = 1;
            this.tabPageCondition.Text = "解析の条件";
            this.tabPageCondition.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.AutoSize = true;
            this.buttonSaveSetting.Location = new System.Drawing.Point(181, 265);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(131, 42);
            this.buttonSaveSetting.TabIndex = 24;
            this.buttonSaveSetting.Text = "設定保存";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.ButtonSaveSetting_Click);
            // 
            // checkBoxAngle
            // 
            this.checkBoxAngle.AutoSize = true;
            this.checkBoxAngle.Checked = true;
            this.checkBoxAngle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAngle.Location = new System.Drawing.Point(286, 223);
            this.checkBoxAngle.Name = "checkBoxAngle";
            this.checkBoxAngle.Size = new System.Drawing.Size(162, 19);
            this.checkBoxAngle.TabIndex = 23;
            this.checkBoxAngle.Text = "物体の向きを検出する";
            this.checkBoxAngle.UseVisualStyleBackColor = true;
            this.checkBoxAngle.CheckedChanged += new System.EventHandler(this.CondisionCtrlValueChanged);
            // 
            // comboBoxShape
            // 
            this.comboBoxShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShape.FormattingEnabled = true;
            this.comboBoxShape.Location = new System.Drawing.Point(117, 217);
            this.comboBoxShape.Name = "comboBoxShape";
            this.comboBoxShape.Size = new System.Drawing.Size(121, 23);
            this.comboBoxShape.TabIndex = 22;
            this.comboBoxShape.SelectedIndexChanged += new System.EventHandler(this.CondisionCtrlValueChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 30);
            this.label9.TabIndex = 21;
            this.label9.Text = "物体の形状";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.AutoSize = true;
            this.buttonAnalyze.Location = new System.Drawing.Point(329, 265);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(131, 42);
            this.buttonAnalyze.TabIndex = 20;
            this.buttonAnalyze.Text = "解析開始";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.ButtonAnalyze_Click);
            // 
            // pictureBoxTarget
            // 
            this.pictureBoxTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTarget.Location = new System.Drawing.Point(117, 171);
            this.pictureBoxTarget.Name = "pictureBoxTarget";
            this.pictureBoxTarget.Size = new System.Drawing.Size(50, 22);
            this.pictureBoxTarget.TabIndex = 19;
            this.pictureBoxTarget.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 30);
            this.label8.TabIndex = 18;
            this.label8.Text = "検出対象の色";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericBinary
            // 
            this.numericBinary.Location = new System.Drawing.Point(367, 171);
            this.numericBinary.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericBinary.Name = "numericBinary";
            this.numericBinary.Size = new System.Drawing.Size(71, 22);
            this.numericBinary.TabIndex = 17;
            this.numericBinary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBinary.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericBinary.ValueChanged += new System.EventHandler(this.CondisionCtrlValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(261, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 30);
            this.label7.TabIndex = 15;
            this.label7.Text = "検出閾値";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonEFrame
            // 
            this.buttonEFrame.AutoSize = true;
            this.buttonEFrame.Location = new System.Drawing.Point(423, 125);
            this.buttonEFrame.Name = "buttonEFrame";
            this.buttonEFrame.Size = new System.Drawing.Size(37, 25);
            this.buttonEFrame.TabIndex = 14;
            this.buttonEFrame.Text = "set";
            this.buttonEFrame.UseVisualStyleBackColor = true;
            this.buttonEFrame.Click += new System.EventHandler(this.ButtonEFrame_Click);
            // 
            // buttonSFrame
            // 
            this.buttonSFrame.AutoSize = true;
            this.buttonSFrame.Location = new System.Drawing.Point(173, 123);
            this.buttonSFrame.Name = "buttonSFrame";
            this.buttonSFrame.Size = new System.Drawing.Size(37, 25);
            this.buttonSFrame.TabIndex = 13;
            this.buttonSFrame.Text = "set";
            this.buttonSFrame.UseVisualStyleBackColor = true;
            this.buttonSFrame.Click += new System.EventHandler(this.ButtonSFrame_Click);
            // 
            // textBoxEFrame
            // 
            this.textBoxEFrame.Location = new System.Drawing.Point(367, 128);
            this.textBoxEFrame.Name = "textBoxEFrame";
            this.textBoxEFrame.ReadOnly = true;
            this.textBoxEFrame.Size = new System.Drawing.Size(50, 22);
            this.textBoxEFrame.TabIndex = 12;
            this.textBoxEFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(261, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "終了フレーム";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSFrame
            // 
            this.textBoxSFrame.Location = new System.Drawing.Point(117, 125);
            this.textBoxSFrame.Name = "textBoxSFrame";
            this.textBoxSFrame.ReadOnly = true;
            this.textBoxSFrame.Size = new System.Drawing.Size(50, 22);
            this.textBoxSFrame.TabIndex = 10;
            this.textBoxSFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "開始フレーム";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(173, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "m";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRuler
            // 
            this.textBoxRuler.Location = new System.Drawing.Point(117, 78);
            this.textBoxRuler.Name = "textBoxRuler";
            this.textBoxRuler.Size = new System.Drawing.Size(50, 22);
            this.textBoxRuler.TabIndex = 5;
            this.textBoxRuler.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRuler.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxRuler_Validating);
            this.textBoxRuler.Validated += new System.EventHandler(this.TextBoxValidating);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "基準の長さ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFPS
            // 
            this.textBoxFPS.Location = new System.Drawing.Point(367, 36);
            this.textBoxFPS.Name = "textBoxFPS";
            this.textBoxFPS.Size = new System.Drawing.Size(50, 22);
            this.textBoxFPS.TabIndex = 3;
            this.textBoxFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFPS.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxFPS_Validating);
            this.textBoxFPS.Validated += new System.EventHandler(this.TextBoxValidating);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(283, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "FPS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFrameCount
            // 
            this.textBoxFrameCount.Location = new System.Drawing.Point(117, 33);
            this.textBoxFrameCount.Name = "textBoxFrameCount";
            this.textBoxFrameCount.ReadOnly = true;
            this.textBoxFrameCount.Size = new System.Drawing.Size(50, 22);
            this.textBoxFrameCount.TabIndex = 1;
            this.textBoxFrameCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "総フレーム";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Controls.Add(this.checkBoxRevYaxis);
            this.tabPageGraph.Controls.Add(this.label12);
            this.tabPageGraph.Controls.Add(this.numericUpDownXaxis);
            this.tabPageGraph.Controls.Add(this.numericUpDownStorobo);
            this.tabPageGraph.Controls.Add(this.label11);
            this.tabPageGraph.Controls.Add(this.numericUpDownWindow);
            this.tabPageGraph.Controls.Add(this.label10);
            this.tabPageGraph.Location = new System.Drawing.Point(4, 25);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraph.Size = new System.Drawing.Size(488, 349);
            this.tabPageGraph.TabIndex = 2;
            this.tabPageGraph.Text = "グラフの設定";
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // checkBoxRevYaxis
            // 
            this.checkBoxRevYaxis.AutoSize = true;
            this.checkBoxRevYaxis.Location = new System.Drawing.Point(232, 147);
            this.checkBoxRevYaxis.Name = "checkBoxRevYaxis";
            this.checkBoxRevYaxis.Size = new System.Drawing.Size(118, 19);
            this.checkBoxRevYaxis.TabIndex = 23;
            this.checkBoxRevYaxis.Text = "Y軸を反転する";
            this.checkBoxRevYaxis.UseVisualStyleBackColor = true;
            this.checkBoxRevYaxis.CheckedChanged += new System.EventHandler(this.GraphCtrlValueChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(18, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 30);
            this.label12.TabIndex = 22;
            this.label12.Text = "X軸の向き";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownXaxis
            // 
            this.numericUpDownXaxis.Location = new System.Drawing.Point(124, 144);
            this.numericUpDownXaxis.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericUpDownXaxis.Name = "numericUpDownXaxis";
            this.numericUpDownXaxis.Size = new System.Drawing.Size(71, 22);
            this.numericUpDownXaxis.TabIndex = 21;
            this.numericUpDownXaxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownXaxis.ValueChanged += new System.EventHandler(this.GraphCtrlValueChanged);
            // 
            // numericUpDownStorobo
            // 
            this.numericUpDownStorobo.Location = new System.Drawing.Point(124, 85);
            this.numericUpDownStorobo.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownStorobo.Name = "numericUpDownStorobo";
            this.numericUpDownStorobo.Size = new System.Drawing.Size(71, 22);
            this.numericUpDownStorobo.TabIndex = 21;
            this.numericUpDownStorobo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownStorobo.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownStorobo.ValueChanged += new System.EventHandler(this.GraphCtrlValueChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(18, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 30);
            this.label11.TabIndex = 20;
            this.label11.Text = "ストロボの間隔";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownWindow
            // 
            this.numericUpDownWindow.DecimalPlaces = 1;
            this.numericUpDownWindow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownWindow.Location = new System.Drawing.Point(124, 27);
            this.numericUpDownWindow.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownWindow.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownWindow.Name = "numericUpDownWindow";
            this.numericUpDownWindow.Size = new System.Drawing.Size(71, 22);
            this.numericUpDownWindow.TabIndex = 19;
            this.numericUpDownWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownWindow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownWindow.ValueChanged += new System.EventHandler(this.GraphCtrlValueChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(18, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 30);
            this.label10.TabIndex = 18;
            this.label10.Text = "窓のサイズ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageAggregate
            // 
            this.tabPageAggregate.Controls.Add(this.buttonAggregate);
            this.tabPageAggregate.Controls.Add(this.listBoxAggregate);
            this.tabPageAggregate.Location = new System.Drawing.Point(4, 25);
            this.tabPageAggregate.Name = "tabPageAggregate";
            this.tabPageAggregate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAggregate.Size = new System.Drawing.Size(488, 349);
            this.tabPageAggregate.TabIndex = 3;
            this.tabPageAggregate.Text = "グラフの集約";
            this.tabPageAggregate.UseVisualStyleBackColor = true;
            // 
            // buttonAggregate
            // 
            this.buttonAggregate.AutoSize = true;
            this.buttonAggregate.Location = new System.Drawing.Point(304, 272);
            this.buttonAggregate.Name = "buttonAggregate";
            this.buttonAggregate.Size = new System.Drawing.Size(146, 25);
            this.buttonAggregate.TabIndex = 1;
            this.buttonAggregate.Text = "テキストファイルに保存";
            this.buttonAggregate.UseVisualStyleBackColor = true;
            this.buttonAggregate.Click += new System.EventHandler(this.ButtonAggregate_Click);
            // 
            // listBoxAggregate
            // 
            this.listBoxAggregate.FormattingEnabled = true;
            this.listBoxAggregate.ItemHeight = 15;
            this.listBoxAggregate.Location = new System.Drawing.Point(27, 38);
            this.listBoxAggregate.Name = "listBoxAggregate";
            this.listBoxAggregate.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAggregate.Size = new System.Drawing.Size(239, 259);
            this.listBoxAggregate.TabIndex = 0;
            this.listBoxAggregate.SelectedIndexChanged += new System.EventHandler(this.ListBoxAggregate_SelectedIndexChanged);
            // 
            // tabPageLamp
            // 
            this.tabPageLamp.Controls.Add(this.buttonLamp);
            this.tabPageLamp.Controls.Add(this.listBoxLamp);
            this.tabPageLamp.Location = new System.Drawing.Point(4, 25);
            this.tabPageLamp.Name = "tabPageLamp";
            this.tabPageLamp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLamp.Size = new System.Drawing.Size(488, 349);
            this.tabPageLamp.TabIndex = 4;
            this.tabPageLamp.Text = "まとめて解析";
            this.tabPageLamp.UseVisualStyleBackColor = true;
            // 
            // buttonLamp
            // 
            this.buttonLamp.AutoSize = true;
            this.buttonLamp.Location = new System.Drawing.Point(310, 279);
            this.buttonLamp.Name = "buttonLamp";
            this.buttonLamp.Size = new System.Drawing.Size(146, 25);
            this.buttonLamp.TabIndex = 3;
            this.buttonLamp.Text = "解析開始";
            this.buttonLamp.UseVisualStyleBackColor = true;
            this.buttonLamp.Click += new System.EventHandler(this.ButtonLamp_Click);
            // 
            // listBoxLamp
            // 
            this.listBoxLamp.FormattingEnabled = true;
            this.listBoxLamp.ItemHeight = 15;
            this.listBoxLamp.Location = new System.Drawing.Point(33, 45);
            this.listBoxLamp.Name = "listBoxLamp";
            this.listBoxLamp.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxLamp.Size = new System.Drawing.Size(239, 259);
            this.listBoxLamp.TabIndex = 2;
            this.listBoxLamp.SelectedIndexChanged += new System.EventHandler(this.ListBoxLamp_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(496, 378);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControllerForm";
            this.ShowInTaskbar = false;
            this.Text = "コントロール";
            this.tabControl.ResumeLayout(false);
            this.tabPageSelect.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageCondition.ResumeLayout(false);
            this.tabPageCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBinary)).EndInit();
            this.tabPageGraph.ResumeLayout(false);
            this.tabPageGraph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXaxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStorobo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindow)).EndInit();
            this.tabPageAggregate.ResumeLayout(false);
            this.tabPageAggregate.PerformLayout();
            this.tabPageLamp.ResumeLayout(false);
            this.tabPageLamp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSelect;
        private System.Windows.Forms.TabPage tabPageCondition;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TextBox textBoxRuler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrameCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonEFrame;
        private System.Windows.Forms.Button buttonSFrame;
        private System.Windows.Forms.TextBox textBoxEFrame;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericBinary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxTarget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.ComboBox comboBoxShape;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxAngle;
        private System.Windows.Forms.Button buttonSaveSetting;
        private System.Windows.Forms.NumericUpDown numericUpDownWindow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownStorobo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxViewMode;
        private System.Windows.Forms.TabPage tabPageAggregate;
        private System.Windows.Forms.Button buttonAggregate;
        private System.Windows.Forms.ListBox listBoxAggregate;
        private System.Windows.Forms.CheckBox checkBoxRevYaxis;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownXaxis;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabPage tabPageLamp;
        private System.Windows.Forms.Button buttonLamp;
        private System.Windows.Forms.ListBox listBoxLamp;
    }
}