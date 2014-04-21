using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
using Functional.Contracts.Utility;

namespace Functional.Language.Implimentation {
    public class TokenizerState : ITokenizerState {
        public string Name { get; private set; }

        public bool CharacterHandled { get; set; }
        public Func<ICharacter, IStream<IToken>, Queue<char>, bool> Handle { get; set; }
        private TokenizerState() { } // no empty constructor
        public TokenizerState(string name) {
            this.Name = name;
            this.Handle = this.handle;
            this.DefaultNextState = this; 
        }
        private bool handle(ICharacter c, IStream<IToken> tokenStream, Queue<char> queue) {
            return true;
        }
        protected IDictionary<CharKind, ITokenizerState> ExitState = new Dictionary<CharKind, ITokenizerState>();
        public ITokenizerState DefaultNextState { get; set; }
        public void AddTransitionState(CharKind cKind, ITokenizerState next) {
            this.ExitState[cKind] = next;
        }
        public ITokenizerState NextState(CharKind charKind) {
            return (this.ExitState.Keys.Contains(charKind)) ? this.ExitState[charKind] : this.DefaultNextState;
        }
        public override string ToString() { return this.Name; }
    }
}
