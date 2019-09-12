using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MotionAnalyzer2 {
    public partial class ProgressDialog : Form {
        public ProgressDialog(string caption, DoWorkEventHandler doWork) {
            InitializeComponent();
            this.Text = caption;
            backgroundWorker.DoWork += doWork;
        }

        private void ProgressDialog_Shown(object sender, EventArgs e) {
            backgroundWorker.RunWorkerAsync();
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            buttonCancel.Enabled = false;
            backgroundWorker.CancelAsync();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            int value = Math.Max(e.ProgressPercentage, progressBar.Minimum);
            value = Math.Min(value, progressBar.Maximum);
            progressBar.Value = value;
            this.label.Text = string.Format("{0}/{1}", value, progressBar.Maximum);
            this.label.Text = (string)e.UserState;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.DialogResult = e.Cancelled ? DialogResult.Cancel : DialogResult.OK;
            this.Close();
        }
    }
}
