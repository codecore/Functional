using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class LexerState : ILexerState {
        public string Name { get; private set; }

        public bool CharacterHandled { get; set; }
        public Func<ICharacter, ITokenStream, Queue<char>, bool> Handle { get; set; }
        private LexerState() { } // no empty constructor
        public LexerState(string name) {
            this.Name = name;
            this.Handle = this.handle;
            this.DefaultNextState = this; 
        }
        private bool handle(ICharacter c, ITokenStream tokenStream, Queue<char> queue) {
            return true;
        }
        protected IDictionary<CharKind, ILexerState> ExitState = new Dictionary<CharKind, ILexerState>();
        public ILexerState DefaultNextState { get; set; }
        public void AddTransitionState(CharKind cKind, ILexerState next) {
            this.ExitState[cKind] = next;
        }
        public ILexerState NextState(CharKind charKind) {
            return (this.ExitState.Keys.Contains(charKind)) ? this.ExitState[charKind] : this.DefaultNextState;
        }
        public override string ToString() { return this.Name; }
    }
}
