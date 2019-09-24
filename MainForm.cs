using System.Windows.Forms;

namespace MotionAnalyzer2 {

    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            MainTitle = "";
            AnalyzeDirector.InitFormsAndShow(this);
        }

        public string MainTitle {
            set {
                this.Text = $"MotionAnalyzer2   {value}";
            }
        }
    }
}
