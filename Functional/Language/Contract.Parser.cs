using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functional.Contracts.Utility;

namespace Functional.Language.Contract.Parser {
    public interface ILocation {
        string Filename { get; set; }
        int Line { get; set; }
        int Start { get; set; }
        int Length { get; set; }
        ILocation Next { get; set; }
    }
    public enum CharKind { UNKNOWN, DOT, DASH, COMMA, OPEN_PAREN, CLOSE_PAREN, OPEN_SQ, CLOSE_SQ, PUNCTUATION, ALPHA, DIGIT, QUOTE, SPACE, CARRAGERETURN, LINEFEED, NULL };
    public enum TokenKind { Unknown, Dot, Dash, Comma, Open_Paren, Close_Paren, Open_Sq, Close_Sq, Punctuation, UnquotedWord, LiteralInteger, LiteralFloat, LiteralString, OneOrMoreSpace, CarrageReturn, LineFeed, NULL };
    public interface ICharacter {
        char Info { get; set; }
        CharKind Kind { get; set; }
        ICharacter Next { get; set; }
    }
    public interface ICharacterStream {
        void Initialize(IInputStream stream);
        Task<ICharacter> Get();         // get the next character n the stream
        void Push(ICharacter c);  // push the character back to the stream
        void Put(ICharacter c);   // Unknown YODO
        bool EOF { get; }         // the stream is at the end of the file
    }
    public interface IToken {
        ILocation Location { get; set; }
        string Info { get; set; }
        TokenKind Kind { get; set; }
        IToken Next { get; set; }
    }
    public interface IFalseToken {
        string Info { get; set; }
        TokenKind Kind { get; set; }
    }

    public interface ITokenizer {
        int StartOfCurrentToken { get; }
        int Line { get; }
        int Position { get; }
        string Filename { get; }
        void Initialize();
        Task Tokenize(IStream<IToken> tokenStream, ICharacterStream characterStream, string filename, int startLine, int startPosition);
    }
    public interface ITokenizerState {
        string Name { get; }
        void AddTransitionState(CharKind c, ITokenizerState next);
        Func<ICharacter, IStream<IToken>, Queue<char>, bool> Handle { get; set; }
        ITokenizerState NextState(CharKind ck);
        ITokenizerState DefaultNextState { set; }
    }
    public interface IParserContext { 
        // this has current known type
        IEnumerable<Type> KnownTypes { get; }
        void Add(Type type);
    }
    public interface IParser : IDisposable {
        IParserContext Context { get; }
        Task Initialize();
        IEnumerable<string> Keywords { get; }
        IEnumerable<string> Variables { get; }
        IEnumerable<string> Types { get; }
        Task<IStream<IToken>> Tokenize();
    }
}
