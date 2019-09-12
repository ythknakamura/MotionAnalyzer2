namespace MotionAnalyzer2 {
    partial class ImageForm {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.labelFrame = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.radioButtonTrajectory = new System.Windows.Forms.RadioButton();
            this.radioButtonStrobo = new System.Windows.Forms.RadioButton();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.radioButtonBinary = new System.Windows.Forms.RadioButton();
            this.radioButtonDetect = new System.Windows.Forms.RadioButton();
            this.radioButtonRange = new System.Windows.Forms.RadioButton();
            this.radioButtonRaw = new System.Windows.Forms.RadioButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBoxIpl = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar);
            this.panel1.Controls.Add(this.labelFrame);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 50);
            this.panel1.TabIndex = 1;
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar.LargeChange = 10;
            this.trackBar.Location = new System.Drawing.Point(120, 0);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(857, 50);
            this.trackBar.TabIndex = 1;
            this.trackBar.TickFrequency = 0;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // labelFrame
            // 
            this.labelFrame.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelFrame.Location = new System.Drawing.Point(0, 0);
            this.labelFrame.Name = "labelFrame";
            this.labelFrame.Padding = new System.Windows.Forms.Padding(15);
            this.labelFrame.Size = new System.Drawing.Size(120, 50);
            this.labelFrame.TabIndex = 0;
            this.labelFrame.Text = "フレーム";
            this.labelFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radioButtonTrajectory);
            this.groupBox.Controls.Add(this.radioButtonStrobo);
            this.groupBox.Controls.Add(this.buttonSaveImage);
            this.groupBox.Controls.Add(this.radioButtonBinary);
            this.groupBox.Controls.Add(this.radioButtonDetect);
            this.groupBox.Controls.Add(this.radioButtonRange);
            this.groupBox.Controls.Add(this.radioButtonRaw);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 570);
            this.groupBox.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(977, 75);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // radioButtonTrajectory
            // 
            this.radioButtonTrajectory.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonTrajectory.Location = new System.Drawing.Point(555, 23);
            this.radioButtonTrajectory.Name = "radioButtonTrajectory";
            this.radioButtonTrajectory.Size = new System.Drawing.Size(100, 40);
            this.radioButtonTrajectory.TabIndex = 6;
            this.radioButtonTrajectory.Text = "軌跡表示";
            this.radioButtonTrajectory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonTrajectory.UseVisualStyleBackColor = true;
            this.radioButtonTrajectory.Visible = false;
            this.radioButtonTrajectory.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonStrobo
            // 
            this.radioButtonStrobo.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonStrobo.Location = new System.Drawing.Point(447, 23);
            this.radioButtonStrobo.Name = "radioButtonStrobo";
            this.radioButtonStrobo.Size = new System.Drawing.Size(100, 40);
            this.radioButtonStrobo.TabIndex = 5;
            this.radioButtonStrobo.Text = "ストロボ";
            this.radioButtonStrobo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonStrobo.UseVisualStyleBackColor = true;
            this.radioButtonStrobo.Visible = false;
            this.radioButtonStrobo.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveImage.AutoSize = true;
            this.buttonSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSaveImage.Location = new System.Drawing.Point(850, 23);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(115, 40);
            this.buttonSaveImage.TabIndex = 4;
            this.buttonSaveImage.Text = "この画像の保存";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.ButtonSaveImage_Click);
            // 
            // radioButtonBinary
            // 
            this.radioButtonBinary.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonBinary.Location = new System.Drawing.Point(231, 23);
            this.radioButtonBinary.Name = "radioButtonBinary";
            this.radioButtonBinary.Size = new System.Drawing.Size(100, 40);
            this.radioButtonBinary.TabIndex = 3;
            this.radioButtonBinary.Text = "二値化";
            this.radioButtonBinary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonBinary.UseVisualStyleBackColor = true;
            this.radioButtonBinary.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonDetect
            // 
            this.radioButtonDetect.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonDetect.Location = new System.Drawing.Point(339, 23);
            this.radioButtonDetect.Name = "radioButtonDetect";
            this.radioButtonDetect.Size = new System.Drawing.Size(100, 40);
            this.radioButtonDetect.TabIndex = 2;
            this.radioButtonDetect.Text = "検出結果";
            this.radioButtonDetect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonDetect.UseVisualStyleBackColor = true;
            this.radioButtonDetect.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonRange
            // 
            this.radioButtonRange.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonRange.Location = new System.Drawing.Point(123, 23);
            this.radioButtonRange.Name = "radioButtonRange";
            this.radioButtonRange.Size = new System.Drawing.Size(100, 40);
            this.radioButtonRange.TabIndex = 1;
            this.radioButtonRange.Text = "解析範囲";
            this.radioButtonRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonRange.UseVisualStyleBackColor = true;
            this.radioButtonRange.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonRaw
            // 
            this.radioButtonRaw.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonRaw.Checked = true;
            this.radioButtonRaw.Location = new System.Drawing.Point(15, 23);
            this.radioButtonRaw.Name = "radioButtonRaw";
            this.radioButtonRaw.Size = new System.Drawing.Size(100, 40);
            this.radioButtonRaw.TabIndex = 0;
            this.radioButtonRaw.TabStop = true;
            this.radioButtonRaw.Text = "入力画像";
            this.radioButtonRaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonRaw.UseVisualStyleBackColor = true;
            this.radioButtonRaw.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.Filter = "jpgファイル|*.jpg";
            this.saveFileDialog.Title = "表示中の画像の保存";
            // 
            // pictureBoxIpl
            // 
            this.pictureBoxIpl.BackColor = System.Drawing.Color.Black;
            this.pictureBoxIpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIpl.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIpl.Name = "pictureBoxIpl";
            this.pictureBoxIpl.Size = new System.Drawing.Size(977, 520);
            this.pictureBoxIpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIpl.TabIndex = 3;
            this.pictureBoxIpl.TabStop = false;
            this.pictureBoxIpl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 645);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxIpl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox);
            this.Enabled = false;
            this.Name = "ImageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "イメージ";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioButtonRaw;
        private System.Windows.Forms.Label labelFrame;
        private System.Windows.Forms.RadioButton radioButtonDetect;
        private System.Windows.Forms.RadioButton radioButtonRange;
        private System.Windows.Forms.RadioButton radioButtonBinary;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl;
        private System.Windows.Forms.RadioButton radioButtonTrajectory;
        private System.Windows.Forms.RadioButton radioButtonStrobo;
    }
}