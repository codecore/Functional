using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class Token : IToken {
        public ILocation Location { get; set; }
        public String Info { get; set; }
        public TokenKind Kind { get; set; }
        public IToken Next { get; set; }
        private Token() { }
        private Token(ILocation location, string info, TokenKind kind) {
            this.Location = location;
            this.Location.Length = info.Length;
            this.Info = info;
            this.Kind = kind;
        }
        public override string ToString() { return this.Info+":"+this.Kind.ToString(); }
        public static IToken Create(ILocation location, string info, TokenKind kind) {
            return new Token(location, info, kind);
        }
    }
    public class FalseToken : IFalseToken {
        public string Info { get; set; }
        public TokenKind Kind { get; set; }
        public override string ToString() { return this.Info + ":" + this.Kind.ToString(); }
        private FalseToken(string info, TokenKind kind) {
            this.Info = info;
            this.Kind = kind;
        }
        public static IFalseToken Create(string info, TokenKind kind) {
            return new FalseToken(info, kind);
        }
    }
    public class LanguageToken {
    }
}
