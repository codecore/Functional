using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using Functional.Language.Contract;
using Functional.Language.Implimentation;
namespace Functional.Language.Implimentation {
    [Export(typeof(ICharacterStream))]
    public class CharacterStream : ICharacterStream {
        private IGetChar getChar = null;
        private Stack<ICharacter> stack = new Stack<ICharacter>();
        public void Initialize(IGetChar g) { this.getChar = g; }
        public async Task<ICharacter> Get() {
            ICharacter ch = null;
            if (this.stack.Count > 0) ch = this.stack.Pop();
            else {
                if (this.getChar.EOF) ch = MemoryManager.New('~', true);
                else {
                    char c = await this.getChar.Get();
                    ch = MemoryManager.New(c, false);
                }
            }
            return ch;
        }
        public void Push(ICharacter c) { this.stack.Push(c); }
        public void Put(ICharacter c) { }
        public bool EOF { get { return this.getChar.EOF; } }        
    }
}