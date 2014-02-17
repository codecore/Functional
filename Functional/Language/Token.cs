using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class Token : IToken {
        public ILocation Location { get; set; }
        public String Info { get; set; }
        public TokenKind Kind { get; set; }
        public IToken Next { get; set; }
        public Token(ILocation location, string info, TokenKind kind) {
            this.Location = location;
            this.Location.Length = info.Length;
            this.Info = info;
            this.Kind = kind;
        }
        public override string ToString() { return this.Info; }
    }
}
