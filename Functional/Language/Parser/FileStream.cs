using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Implimentation;

using Functional.Utility;

namespace Functional.Language.Implimentation {
    public class InputStream : IInputStream {
        private const int buffer_length = 1024;
        private byte[] byte_buffer = new byte[buffer_length];
        private char[] char_buffer;
        private int char_buffer_length = 0;
        private int char_read_index = 0;
        private bool eof = false;
        private Stream stream;
        public void Initialize(Stream stream) {
            this.stream = stream;
        }
        public async Task<char> ReadAsync() {
            char result = '~';
            if ((!this.eof) && (null != this.stream)) {
                if (this.char_read_index >= this.char_buffer_length) {
                    this.stream.Position = 0L;
                    int r = await this.stream.ReadAsync(this.byte_buffer, 0, buffer_length);
                    if (0 == r) this.eof = true;
                    else {
                        this.char_buffer = Encoding.UTF8.GetChars(this.byte_buffer);
                        this.char_read_index = 0;
                        this.char_buffer_length = this.char_buffer.Length;
                    }
                }
                if ((!this.eof)&&(null != this.char_buffer)) {
                    result = this.char_buffer[this.char_read_index];
                    this.char_read_index++;
                }
            }
            return result;
        }
        public bool EOF { get { return this.eof; } }
    }
}
