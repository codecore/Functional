using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract.Parser;

namespace Functional.Language.Contract.Editor {
    public interface ICodeLine {
        ICodeDocument Document { get; set; }
        IEnumerable<IToken> Tokens { get; }
        int Line { get; }
        void AddBefore(IToken token);
        void AddAfter(IToken token);
        void Remove();
        void MoveCursorNext();
        void MoveCursorPrev();
        IToken Cursor { get; }
        void FreeMemory();
        ICodeLine Next { get; set; }
    }
    public interface ICodeDocument {
        string Filename { get; }
        IEnumerable<ICodeLine> CodeLines { get; }
        int Line(ICodeLine codeline);
        void AddBefore(ICodeLine codeline);
        void AddAfter(ICodeLine codeline);
        void Remove();
        void MoveCursorNext();
        void MoveCursorPrev();
        ICodeLine Cursor { get; }
        void FreeMemory();
    }
    public enum EditorKind { Real, Fake, Simple };
    public interface IEditor {
        EditorKind Kind { get; }
        IEnumerable<ICodeDocument> CodeDocuments { get; }

    }
    public interface IAutoCompleteItem {
        string Value { get; set; }
    }
    public interface IAutoComplete {
        IEnumerable<IAutoCompleteItem> Items { get; }
        void AddItem(IAutoCompleteItem item);
    }
}
