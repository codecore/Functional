using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;
namespace Functional.Language.Implimentation {
    [Export(typeof(IGetChar))]
    public class GetChar : IGetChar {
        public bool EOF { get { return (null == this.inputStream) ? true : this.inputStream.EOF; } }
        private IInputStream inputStream;
        private string line = String.Empty;
        private int index = 0;
        public void Initialize(IInputStream s) { this.inputStream = s; }
        private async Task readLine() {
            if (!this.inputStream.EOF) {
                string x = await this.inputStream.ReadLine();
                this.line = (null != x) ? x : String.Empty;
                this.index = 0;
            }
        }
        public async Task<char> Get() {
            if (null == this.inputStream) throw new Exception("GetChar has not been initialized");
            char ch = '\0';
            if (String.Empty == this.line) await this.readLine();
            if ((String.Empty != this.line) && (this.index >= this.line.Length)) await this.readLine();
            if (String.Empty != this.line) {
                ch = this.line[this.index];
                this.index++;
            }
            return ch;
        }
    }
}
