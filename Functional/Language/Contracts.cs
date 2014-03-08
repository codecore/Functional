using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Language.Contract {
    public enum InputStreamKind { Mock, File }
    public interface IInputStream : IDisposable {
        InputStreamKind Kind { get; }
        Task Initialize(string filename);
        Task<string> ReadLine();
        bool EOF { get; }
    }
    public interface ILocation {
        string Filename { get; set;  }
        int Line { get; set; }
        int Start { get; set; }
        int Length { get; set; }
        ILocation Next { get; set; }
    }
    public enum CharKind { UNKNOWN, DOT, DASH, COMMA, OPEN_PAREN, CLOSE_PAREN, OPEN_SQ, CLOSE_SQ, PUNCTUATION, ALPHA, DIGIT, QUOTE, SPACE, CARRAGERETURN, LINEFEED, NULL };
    public enum TokenKind { Unknown, Dot, Dash, Comma, Open_Paren, Close_Paren, Open_Sq, Close_Sq, Punctuation, UnquotedWord, LiteralInteger, LiteralFloat, LiteralString, OneOrMoreSpace, CarrageReturn, LineFeed, NULL };
    
    public interface IMemoryManagement<T> {
        T New();
        void Delete(T t);
    }
    public interface ICodeLine  {
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
    public interface ICharacter
    {
        char Info { get; set; }
        CharKind Kind { get; set; }
        ICharacter Next { get; set; }
    }
    public interface IGetChar {
        void Initialize(IInputStream i);
        Task<char> Get();
        bool EOF { get; }
    }
    public interface ICharacterStream
    {
        void Initialize(IGetChar g);
        Task<ICharacter> Get();         // get the next character n the stream
        void Push(ICharacter c);  // push the character back to the stream
        void Put(ICharacter c);   // Unknown YODO
        bool EOF { get; }         // the stream is at the end of the file
    }
    public interface IToken
    {
        ILocation Location { get; set; }
        string Info { get; set; }
        TokenKind Kind { get; set; }
        IToken Next { get; set; }
    }
    public interface ITokenStream
    {
        IToken Get();
        void Push(IToken t);
        void Put(IToken t);
        void Clear();
    }
    public interface ILexer
    {
        int StartOfCurrentToken { get; }
        int Line { get; }
        int Position { get; }
        string Filename { get; }
        void Initialize();
        Task Parse(ITokenStream tokenStream, ICharacterStream characterStream, string filename, int startLine, int startPosition);
    }
    public interface ILexerState
    {
        string Name { get; }
        void AddTransitionState(CharKind c, ILexerState next);
        Func<ICharacter, ITokenStream, Queue<char>,bool> Handle { get; set; }
        ILexerState NextState(CharKind ck);
        ILexerState DefaultNextState { set; }
    }


    public interface IAutoCompleteItem {
        string Value { get; set; }
    }
    public interface IAutoComplete {
        IEnumerable<IAutoCompleteItem> Items { get; }
        void AddItem(IAutoCompleteItem item);
    }
}
