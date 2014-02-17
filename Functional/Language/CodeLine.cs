using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;
namespace Functional.Language.Implimentation {
    public class CodeLine : ICodeLine {
        public CodeLine(ICodeDocument codedocument) { this.Document = codedocument; }
        public ICodeDocument Document { get; set; }
        public int Line { get { return this.Document.Line(this); } }
        private DLList<IToken> tokens = new DLList<IToken>();
        public IEnumerable<IToken> Tokens { get { return this.tokens; } }
        public void AddBefore(IToken token) { this.tokens.AddBefore(token); }
        public void AddAfter(IToken token) { this.tokens.AddAfter(token); }
        public void Remove() { this.tokens.Remove(); }
        public void MoveCursorNext() { this.tokens.MoveCursorNext(); }
        public void MoveCursorPrev() { this.tokens.MoveCursorPrev(); }
        public IToken Cursor { get { return this.tokens.Cursor; } }
        public void FreeMemory() { this.tokens.FreeMemory(); }
        public ICodeLine Next { get; set; }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (IToken token in this.Tokens) sb.Append(token.ToString());
            return sb.ToString();
        }
    }
}