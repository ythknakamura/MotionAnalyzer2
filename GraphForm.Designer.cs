namespace MotionAnalyzer2 {
    partial class GraphForm {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonCursorReset = new System.Windows.Forms.Button();
            this.labelCursor = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxGraph = new System.Windows.Forms.ComboBox();
            this.saveFileDialogPng = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.CursorX.Interval = 1E-10D;
            chartArea1.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.CursorY.Interval = 1E-10D;
            chartArea1.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.MinimumSize = new System.Drawing.Size(1, 1);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(800, 375);
            this.chart.TabIndex = 0;
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseClick);
            this.chart.MouseLeave += new System.EventHandler(this.Chart_MouseLeave);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseMove);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonCursorReset);
            this.panel.Controls.Add(this.labelCursor);
            this.panel.Controls.Add(this.buttonSave);
            this.panel.Controls.Add(this.comboBoxGraph);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 375);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 75);
            this.panel.TabIndex = 1;
            // 
            // buttonCursorReset
            // 
            this.buttonCursorReset.AutoSize = true;
            this.buttonCursorReset.Location = new System.Drawing.Point(529, 17);
            this.buttonCursorReset.Name = "buttonCursorReset";
            this.buttonCursorReset.Size = new System.Drawing.Size(113, 40);
            this.buttonCursorReset.TabIndex = 5;
            this.buttonCursorReset.Text = "カーソル削除";
            this.buttonCursorReset.UseVisualStyleBackColor = true;
            this.buttonCursorReset.Click += new System.EventHandler(this.ButtonCursorReset_Click);
            // 
            // labelCursor
            // 
            this.labelCursor.AutoSize = true;
            this.labelCursor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCursor.Location = new System.Drawing.Point(350, 25);
            this.labelCursor.Name = "labelCursor";
            this.labelCursor.Size = new System.Drawing.Size(39, 22);
            this.labelCursor.TabIndex = 4;
            this.labelCursor.Text = "( , )";
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(662, 17);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(113, 40);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "このグラフを保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // comboBoxGraph
            // 
            this.comboBoxGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraph.FormattingEnabled = true;
            this.comboBoxGraph.Items.AddRange(new object[] {
            "1: 位置のx成分",
            "2: 速度のx成分",
            "3: 加速度のx成分",
            "4: 位置のy成分",
            "5: 速度のy成分",
            "6: 加速度の成分",
            "7: 角度",
            "8: 角速度",
            "9: 角加速度"});
            this.comboBoxGraph.Location = new System.Drawing.Point(12, 27);
            this.comboBoxGraph.Name = "comboBoxGraph";
            this.comboBoxGraph.Size = new System.Drawing.Size(223, 23);
            this.comboBoxGraph.TabIndex = 2;
            this.comboBoxGraph.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGraph_SelectedIndexChanged);
            // 
            // saveFileDialogPng
            // 
            this.saveFileDialogPng.DefaultExt = "png";
            this.saveFileDialogPng.Filter = "pngファイル|*.png";
            this.saveFileDialogPng.Title = "表示中のグラフの保存";
            // 
            // saveFileDialogCSV
            // 
            this.saveFileDialogCSV.DefaultExt = "csv";
            this.saveFileDialogCSV.Filter = "csvファイル|*.csv";
            this.saveFileDialogCSV.Title = "集約グラフデータの出力";
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.chart);
            this.Controls.Add(this.panel);
            this.Name = "GraphForm";
            this.ShowInTaskbar = false;
            this.Text = "グラフ";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox comboBoxGraph;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPng;
        private System.Windows.Forms.Label labelCursor;
        private System.Windows.Forms.Button buttonCursorReset;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
    }
}