using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class CodeDocument : ICodeDocument {
        public string Filename { get { return "Simple"; } }
        private DLList<ICodeLine> codelines = new DLList<ICodeLine>();
        public IEnumerable<ICodeLine> CodeLines { get { return this.codelines; } }
        public int Line(ICodeLine codeline) {
            return -1;
        }
        public void AddBefore(ICodeLine codeline) { this.codelines.AddBefore(codeline); }
        public void AddAfter(ICodeLine codeline) { this.codelines.AddAfter(codeline); }
        public void Remove() { this.codelines.Remove(); }
        public void MoveCursorNext() { this.codelines.MoveCursorNext(); }
        public void MoveCursorPrev() { this.codelines.MoveCursorPrev(); }
        public ICodeLine Cursor { get { return this.codelines.Cursor; } }
        public void FreeMemory() { this.codelines.FreeMemory(); }
        public CodeDocument() { }
        public ICodeDocument Next { get; set; }
    }
}
