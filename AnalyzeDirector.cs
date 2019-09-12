using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace MotionAnalyzer2 {
    public interface IChildForm {
        void UpdateCtrl();
    }

    public static class AnalyzeDirector {
        public enum Children { Controll, Image, Graph };
        public enum TabMode {Select, Condition, Graph, Aggregate};

        public static bool Loaded { get { return VideoImaging != null; } }
        public static bool Analized { get { return MotionData != null; } }
        public static TabMode Tab{ get; set;}

        public static Dictionary<Children, IChildForm> ChildForm;
        public static ControllerForm ControllerForm { get { return (ControllerForm)ChildForm[Children.Controll]; } }
        public static ImageForm ImageForm { get { return (ImageForm)ChildForm[Children.Image]; } }
        public static GraphForm GraphForm { get { return (GraphForm)ChildForm[Children.Graph]; } }

        public static Parameters Parameters;
        public static VideoImaging VideoImaging;
        public static MotionData MotionData;

        static AnalyzeDirector() {
            ChildForm = new Dictionary<Children, IChildForm>() {
                [Children.Controll] = new ControllerForm(),
                [Children.Image] = new ImageForm(),
                [Children.Graph] = new GraphForm(),
            };
        }

        public static void InitFormsAndShow(MainForm parent) {
            foreach (var f in ChildForm) {
                (f.Value as Form).MdiParent = parent;
                (f.Value as Form).Show();
            }
            VideoImaging = null;
            MotionData = null;
            UpdateAllControll();
        }

        public static void UpdateAllControll() {
            foreach (var f in ChildForm) f.Value.UpdateCtrl();
        }

        public static void LoadVideoBtnClick(string videoFile) {
            VideoImaging = VideoImaging.Load(videoFile);
            if (VideoImaging == null) {
                Parameters = null;
                MotionData = null;
            }
            else {
                Parameters = Parameters.LoadOrCreate(videoFile, VideoImaging);
                MotionData = MotionData.TryLoadRawData(videoFile, Parameters);
                ImageForm.LoadVideo(VideoImaging, Parameters.StartFrame);
                if (MotionData != null) {
                    GraphForm.LoadData(MotionData);
                }
            }
            UpdateAllControll();
            ControllerForm.SwitchTab();
        }
        public static void AnalyzeAllBtnClick() {
            Parameters.Save();
            MotionData = VideoImaging.AnalizeAll(Parameters);
            if (MotionData != null) {
                MotionData.SaveRawData(Parameters.VideoFile);
                GraphForm.LoadData(MotionData);
            }
            UpdateAllControll();
            ControllerForm.SwitchTab();
        }

        public static void AggregateListChanged(IEnumerable<string> selectedlist) {
            var motionDatas = selectedlist
                .Select(file => MotionData.TryLoadRawData(file, Parameters.LoadOrCreate(file, null)))
                .Where(md => md != null);
            GraphForm.LoadManyData(motionDatas);
        }
        public static void SaveAggregateData() {
            GraphForm.SaveManyData();
        }
    }
}