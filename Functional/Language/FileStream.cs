using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Implimentation;
namespace Functional.Language.Implimentation {
    [Export(typeof(IInputStream))]
    public class InputStreamMock : IInputStream {
        private string s1 = String.Empty;
        private int index = 0;
        private int count = 0;
        private InputStreamMock() { }
        public InputStreamMock(int c, string s) { this.count = (c > 0) ? c : 10; this.s1 = s; }
        public InputStreamKind Kind { get { return InputStreamKind.Mock; } }
        public async Task Initialize(string filename) { await Task.Delay(10); }
        public async Task<string> ReadLine() {
            string result = String.Empty;
            if (this.index < this.count) result = s1;
            else this.EOF = true;
            this.index++; // overflow bug
            await Task.Delay(10);
            return result;
        }
        public bool EOF { get; private set; }
        public void Dispose() { }
    }
    [Export(typeof(IInputStream))]
    public class InputStreamFile : IInputStream {
        private bool eof = false;
        private StreamReader reader;
        public InputStreamKind Kind { get { return InputStreamKind.File; } }
        public async Task Initialize(string filename) {
            if (String.IsNullOrEmpty(filename)) throw new ArgumentException("filename must be valid");
            if (Utility.FileExists(filename)) {
                this.reader = new StreamReader(filename, Encoding.Unicode, true);
            } else throw new ArgumentException(String.Format("file {%0} does not exist ", filename));
            await Task.Delay(0); // quit bitching about no awaits in async method
        }
        public async Task<string> ReadLine() {
            string result = String.Empty;
            if (null != this.reader) {
                if (this.reader.EndOfStream) {
                    this.eof = true;
                } else result = await this.reader.ReadLineAsync();
            }
            return result;
        }
        public bool EOF { get { return this.eof; } }
        public void Dispose() {
            if (null != this.reader) {
                this.reader.Dispose();
                this.reader = null;
            }
        }
    }
}
