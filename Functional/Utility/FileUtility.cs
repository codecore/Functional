using System;
using System.IO;
namespace Functional.Utility {
    public static class FileUtility {
        public static void DeleteFile(string filename) {
            if (File.Exists(filename)) {
                File.Delete(filename);
            }
        }
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