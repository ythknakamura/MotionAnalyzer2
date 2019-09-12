using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MotionAnalyzer2 {
    public static class Settings {
  
        static readonly string[] videoExt = { ".mov", ".mp4", ".avi", ".m4a", ".wmv", ".mts" };
        static readonly string baseDir;
        static Settings() {
            baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(VideoDir)) Directory.CreateDirectory(VideoDir);
            if (!Directory.Exists(OutputDir)) Directory.CreateDirectory(OutputDir);
        }

        private static string VideoDir {
            get { return Path.Combine(baseDir, "Video"); }
        }

        public static string OutputDir {
            get { return Path.Combine(baseDir, "Output"); }
        }

        public static string VideoFullPath(string videoFile) {
            return Path.Combine(VideoDir, videoFile);
        }
        public static string VideoFile(string videoPath) {
            return Path.GetFileName(videoPath);
        }

        public static string TargetDir(string videoFile) {
            return Path.Combine(OutputDir, videoFile.Replace('.', '_'));
        }

        public static string XmlFilename(string videoFile) {
            return Path.Combine(TargetDir(videoFile), "parameters.xml");
        }
        public static string DetectVideoname(string videoFile) {
            return Path.Combine(TargetDir(videoFile), "detected.mp4");
        }
        public static string RawDataname(string videoFile) {
            return Path.Combine(TargetDir(videoFile), "rawdata.txt");
        }
        public static string PlotDataname(string videoFile) {
            return Path.Combine(TargetDir(videoFile), "plotdata.txt");
        }


        public static IEnumerable<string> VideoFiles {
            get {
                return Directory.EnumerateFiles(VideoDir)
                    .Where(file => videoExt.Any(ext => Path.GetExtension(file).ToLower().EndsWith(ext)))
                    .Select(Path.GetFileName)
                    .OrderBy(file => file);
            }
        }
    }
}