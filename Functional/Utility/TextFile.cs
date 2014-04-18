using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Functional.Implementation;

namespace Functional.Utility {
    public static class TestFile<T>   {
        public static IEnumerable<T> LoadTextFile(string filename, Encoding encoding, Func<string, T> fn) {
            using (TextReader sr = new StreamReader(filename, encoding)) {
                string line = sr.ReadLine();
                while (!String.IsNullOrEmpty(line)) {
                    yield return fn(line);
                    line = sr.ReadLine();
                }
            }
        }
        public static void StoreTextFile(string filename, Encoding encoding, IEnumerable<T> item, Func<T, string> fn) {
            using (TextWriter sw = new StreamWriter(filename, false, encoding)) {
                F.each<string>(F.map<T,string>(item, fn), (s) => sw.WriteLine(s));
            }
        }
    }
}