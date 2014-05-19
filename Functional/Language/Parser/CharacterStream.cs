using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Functional.Language.Contract; 
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
namespace Functional.Language.Implimentation {
    [Export(typeof(ICharacterStream))]
    public class CharacterStream : ICharacterStream {
        private IInputStream stream = null;
        private Stack<ICharacter> stack = new Stack<ICharacter>();
        public void Initialize(IInputStream stream) { this.stream = stream; }
        public async Task<ICharacter> Get() {
            ICharacter ch = null;
            if (this.stack.Count > 0) ch = this.stack.Pop();
            else {
                if (this.stream.EOF) ch = Character.Create('~', true);
                else {
                    char c = await this.stream.ReadAsync();
                    ch = Character.Create(c, this.stream.EOF);
                }
            }
            return ch;
        }
        public void Push(ICharacter c) { this.stack.Push(c); }
        public void Put(ICharacter c) { }
        public bool EOF { get { return this.stream.EOF; } }        
    }
}