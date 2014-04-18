using System;
using System.IO;
using Functional.Test;
namespace Functional.Utility {
    public static class FileUtility {
        [Coverage(TestCoverage.FileUtility_DeleteFile)]
        public static void DeleteFile(string filename) {
            if (File.Exists(filename)) {
                File.Delete(filename);
            }
        }
        [Coverage(TestCoverage.FileUtility_FileExists)]
        public static bool FileExists(string filename) {
            return File.Exists(filename);
        }
        public static long FileLength(string filename) {
            long length = 0L;
            FileStream fs = File.Open(filename, FileMode.Open);
            length = fs.Length;
            fs.Dispose();
            return length;
        }
    }
}