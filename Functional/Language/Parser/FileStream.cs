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

using Functional.Utility;

namespace Functional.Language.Implimentation {
    [Export(typeof(IInputStream))]
    public class InputStreamMock : IInputStream {
        private string buffer = String.Empty;
        private int index = 0;
        public InputStreamKind Kind { get { return InputStreamKind.Mock; } }
        public async Task Initialize(string filename) {
            this.buffer = filename;
            await Task.Delay(10); 
        }
        public async Task<char> ReadAsync() {
            char result = '~';
            if (this.index >= this.buffer.Length) this.EOF = true;
            else result = this.buffer[this.index];
            this.index++;
            await Task.Delay(0);
            return result;
        }
        public bool EOF { get; private set; }
        public void Dispose() { }
    }
    [Export(typeof(IInputStream))]
    public class InputStreamFile : IInputStream {
        private const int buffer_length = 1024;
        private char[] buffer = new char[buffer_length];
        private int readIndex = buffer_length;
        private bool eof = false;
        private StreamReader reader;
        public InputStreamKind Kind { get { return InputStreamKind.File; } }
        public async Task Initialize(string filename) {
            if (String.IsNullOrEmpty(filename)) throw new ArgumentException("filename must be valid");
            if (FileUtility.FileExists(filename)) {
                this.reader = new StreamReader(filename, Encoding.Unicode, true);
            } else throw new ArgumentException(String.Format("file {%0} does not exist ", filename));
            await Task.Delay(0); // quit bitching about no awaits in async method
        }
        public async Task<char> ReadAsync() {
            char result = '~';
            if (null != this.reader) {
                if (this.readIndex >= buffer_length) {
                    if (this.reader.EndOfStream) {
                        this.eof = true;
                    } else {
                        int r = await this.reader.ReadBlockAsync(this.buffer,0,buffer_length);
                        this.readIndex = 0;
                    }
                }
                if (!this.eof) {
                    result = this.buffer[this.readIndex];
                    this.readIndex++;
                }
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
