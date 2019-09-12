using System.Windows.Forms;

namespace MotionAnalyzer2 {

    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            AnalyzeDirector.InitFormsAndShow(this);
        }

    }
}
