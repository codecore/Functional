using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;
using Functional.Implementation;

namespace Functional.Language.Implimentation {
    [Export(typeof(ILexer))]
    public class Lexer : ILexer {
        private ILexerState StartState { get; set; }
        private ILexerState EndState { get; set; }
        private ILexerState ErrorState { get; set; }
        public void Initialize() {
            this.EndState = new LexerState("end");
            this.ErrorState = new LexerState("error");
                ErrorState.DefaultNextState = this.EndState;
            
            this.StartState = new LexerState("start");
                this.StartState.DefaultNextState = ErrorState;
                this.StartState.Handle = (c, tokenStream, queue) => false;
                
            ILexerState createLiteralStringTokenState = new LexerState("create literal string");
                createLiteralStringTokenState.DefaultNextState = this.StartState;
                createLiteralStringTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.LiteralString);
                    return false;
                };
                
            ILexerState inEndQuoteState = new LexerState("in end quote");
                inEndQuoteState.DefaultNextState = createLiteralStringTokenState;
                inEndQuoteState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind, CharKind.QUOTE, c, queue);
                };

            ILexerState inLiteralStringState = new LexerState("in literal string");
                inLiteralStringState.DefaultNextState = inLiteralStringState;
                inLiteralStringState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k != v.Kind, CharKind.QUOTE, c, queue);
                };
                inLiteralStringState.AddTransitionState(CharKind.CARRAGERETURN, this.ErrorState); // unexpected \n
                inLiteralStringState.AddTransitionState(CharKind.NULL, this.ErrorState); // unexpected \0
                inLiteralStringState.AddTransitionState(CharKind.QUOTE, inEndQuoteState);

            ILexerState inStartQuoteState = new LexerState("in start quote");
                inStartQuoteState.DefaultNextState = inLiteralStringState;
                inStartQuoteState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.QUOTE, c, queue);
                };

            ILexerState beginLiteralStringState = new LexerState("begin literal string");
                beginLiteralStringState.DefaultNextState = inStartQuoteState;
                beginLiteralStringState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createPunctuationTokenState = new LexerState("create punctuation token");
                createPunctuationTokenState.DefaultNextState = this.StartState;
                createPunctuationTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Punctuation);
                    return false;
                };

            ILexerState inPunctuationState = new LexerState("in punctuation");
                inPunctuationState.DefaultNextState = createPunctuationTokenState;
                inPunctuationState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.PUNCTUATION, c, queue);
                };

            ILexerState beginPunctuationState = new LexerState("begin punctuation state");
                beginPunctuationState.DefaultNextState = inPunctuationState;
                beginPunctuationState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createFractionTokenState = new LexerState("create fraction token");
                createFractionTokenState.DefaultNextState = this.StartState;
                createFractionTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.LiteralFloat);
                    return false;
                };

            ILexerState inFractionState = new LexerState("in fraction");
                inFractionState.DefaultNextState = createFractionTokenState;
                inFractionState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.DIGIT, c, queue);
                };
                inFractionState.AddTransitionState(CharKind.DIGIT, inFractionState);

            ILexerState beginFractionState = new LexerState("begin fraction");
                beginFractionState.DefaultNextState = inFractionState;
                beginFractionState.Handle = (c, tokenStream, queue) => false;

            ILexerState inDecimalPointState = new LexerState("in decimal point");
                inDecimalPointState.DefaultNextState = this.ErrorState; // there must be a number after the decimal point
                inDecimalPointState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.DOT, c, queue);
                };
                inDecimalPointState.AddTransitionState(CharKind.DOT, beginFractionState); // hack
                inDecimalPointState.AddTransitionState(CharKind.DIGIT, beginFractionState);

            ILexerState beginDecimalPointState = new LexerState("begin decimal point");
                beginDecimalPointState.DefaultNextState = inDecimalPointState;
                beginDecimalPointState.Handle = (c, tokenStream, queue) => {
                    return false;
                };

            ILexerState createLiteralIntegerTokenState = new LexerState("create literal integer token");
                createLiteralIntegerTokenState.DefaultNextState = this.StartState;
                createLiteralIntegerTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.LiteralInteger);
                    return false;
                };

            ILexerState inLiteralNumberState = new LexerState("in number");
                inLiteralNumberState.DefaultNextState = createLiteralIntegerTokenState;
                inLiteralNumberState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.DIGIT, c, queue);
                };
                inLiteralNumberState.AddTransitionState(CharKind.DIGIT, inLiteralNumberState);
                inLiteralNumberState.AddTransitionState(CharKind.DOT, beginDecimalPointState);

            ILexerState beginLiteralNumberState = new LexerState("begin literal number state");
                beginLiteralNumberState.DefaultNextState = inLiteralNumberState;
                beginLiteralNumberState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createOneOrMoreSpaceTokenState = new LexerState("create one or more space token");
                createOneOrMoreSpaceTokenState.DefaultNextState = this.StartState;
                createOneOrMoreSpaceTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.OneOrMoreSpace);
                    return false;
                };

            ILexerState inOneOrMoreSpaceState = new LexerState("in one or more space");
                inOneOrMoreSpaceState.DefaultNextState = createOneOrMoreSpaceTokenState;
                inOneOrMoreSpaceState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.SPACE, c, queue);
                };
                inOneOrMoreSpaceState.AddTransitionState(CharKind.SPACE, inOneOrMoreSpaceState);

            ILexerState beginOneOrMoreSpaceState = new LexerState("begin one or more space");
                beginOneOrMoreSpaceState.DefaultNextState = inOneOrMoreSpaceState;
                beginOneOrMoreSpaceState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createLineFeedTokenState = new LexerState("create line feed token");
                createLineFeedTokenState.DefaultNextState = this.StartState;
                createLineFeedTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.LineFeed);
                    return false;
                };

            ILexerState inLineFeedState = new LexerState("in line feed");
                inLineFeedState.DefaultNextState = createLineFeedTokenState;
                inLineFeedState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.LINEFEED, c, queue);
                };

            ILexerState beginLineFeedState = new LexerState("begin line feed state");
                beginLineFeedState.DefaultNextState = inLineFeedState;
                beginLineFeedState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createCarrageReturnTokenState = new LexerState("create carrage return token");
                createCarrageReturnTokenState.DefaultNextState = this.StartState;
                createCarrageReturnTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.CarrageReturn);
                    ++this.Line;
                    this.Position = 0;
                    return false;
                };

            ILexerState inCarrageReturnState = new LexerState("in carrage return");
                inCarrageReturnState.DefaultNextState = createCarrageReturnTokenState;
                inCarrageReturnState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.CARRAGERETURN, c, queue);
                };

            ILexerState beginCarrageReturnState = new LexerState("begin carrage return");
                beginCarrageReturnState.DefaultNextState = inCarrageReturnState;
                beginCarrageReturnState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createNULLTokenState = new LexerState("create NULL token");
                createNULLTokenState.DefaultNextState = this.EndState; // we go to DONE
                createNULLTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.NULL);
                    return false;
                };

            ILexerState inNULLState = new LexerState("in NULL");
                inNULLState.DefaultNextState = createNULLTokenState;
                inNULLState.Handle = (c, tokenStream, queue) => {
                    bool throwaway = this.HandleStorage((k, v) => k == v.Kind,CharKind.NULL, c, queue);
                    return false; // always return false once we get a null
                };

            ILexerState beginNULLState = new LexerState("begin NULL");
                beginNULLState.DefaultNextState = inNULLState;
                beginNULLState.Handle = (c, tokenStream, queueu) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createAlphaTokenState = new LexerState("create alpha token");
                createAlphaTokenState.DefaultNextState = this.StartState;
                createAlphaTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.UnquotedWord);
                    return false;
                };

            ILexerState inAlphaState = new LexerState("in alpha");
                inAlphaState.DefaultNextState = createAlphaTokenState;
                inAlphaState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.ALPHA, c, queue);
                };
                inAlphaState.AddTransitionState(CharKind.ALPHA, inAlphaState);

            ILexerState beginAlphaState = new LexerState("begin alpha");
                beginAlphaState.DefaultNextState = inAlphaState;
                beginAlphaState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createUnknownCharacterTokenState = new LexerState("create unknown character token");
                createUnknownCharacterTokenState.DefaultNextState = this.StartState;
                createUnknownCharacterTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Unknown);
                    return false;
                };

            ILexerState inUnknownCharacterState = new LexerState("in unknown character");
                inUnknownCharacterState.DefaultNextState = createUnknownCharacterTokenState;
                inUnknownCharacterState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.UNKNOWN, c, queue);
                };
                inUnknownCharacterState.AddTransitionState(CharKind.UNKNOWN, inUnknownCharacterState);

            ILexerState beginUnknownCharacterState = new LexerState("begin unknown character");
                beginUnknownCharacterState.DefaultNextState = inUnknownCharacterState;
                beginUnknownCharacterState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };
            
            ILexerState createDotTokenState = new LexerState("create dot");
                createDotTokenState.DefaultNextState = this.StartState;
                createDotTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Dot);
                    return false;
                };

            ILexerState inDotState = new LexerState("in dot");
                inDotState.DefaultNextState = createDotTokenState;
                inDotState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.DOT, c, queue);
                };

            ILexerState beginDotState = new LexerState("begin dot");
                beginDotState.DefaultNextState = inDotState;
                beginDotState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createDashTokenState = new LexerState("create dash");
                createDashTokenState.DefaultNextState = this.StartState;
                createDashTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Dash);
                    return false;
                };
            ILexerState decideDashOrNegativeState = new LexerState("decide");
                decideDashOrNegativeState.DefaultNextState = createDashTokenState;
                decideDashOrNegativeState.Handle = (c, tokenStream, queue) => false;
                decideDashOrNegativeState.AddTransitionState(CharKind.DIGIT,inLiteralNumberState);

            ILexerState inDashState = new LexerState("in dash");
                inDashState.DefaultNextState = decideDashOrNegativeState ;
                inDashState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind,CharKind.DASH, c, queue);
                };

            ILexerState beginDashState = new LexerState("begin dash");
                beginDashState.DefaultNextState = inDashState;
                beginDashState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createCommaTokenState = new LexerState("create comma"); // candy to help downstream language parser
                createCommaTokenState.DefaultNextState = this.StartState;
                createCommaTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Comma);
                    return false;
                };

            ILexerState inCommaState = new LexerState("in comma");
                inCommaState.DefaultNextState = createCommaTokenState;
                inCommaState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k,v)=>k==v.Kind, CharKind.COMMA, c, queue);
                };

            ILexerState beginCommaState = new LexerState("begin comma");
                beginCommaState.DefaultNextState = inCommaState;
                beginCommaState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createOpenParenTokenState = new LexerState("create open paren token");
                createOpenParenTokenState.DefaultNextState = this.StartState;
                createOpenParenTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Open_Paren);
                    return false;
                };

            ILexerState inOpenParenState = new LexerState("in open paren");
                inOpenParenState.DefaultNextState = createOpenParenTokenState;
                inOpenParenState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind, CharKind.OPEN_PAREN, c, queue);
                };

            ILexerState beginOpenParenState = new LexerState("begin open paren");
                beginOpenParenState.DefaultNextState = inOpenParenState;
                beginOpenParenState.Handle = (c, tokenStream, queueu) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createCloseParenTokenState = new LexerState("create close paren token");
                createCloseParenTokenState.DefaultNextState = this.StartState;
                createCloseParenTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Close_Paren);
                    return false;
                };

            ILexerState inCloseParenState = new LexerState("in close paren");
                inCloseParenState.DefaultNextState = createCloseParenTokenState;
                inCloseParenState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind, CharKind.CLOSE_PAREN, c, queue);
            };
            
            ILexerState beginCloseParenState = new LexerState("begin close paren");
                beginCloseParenState.DefaultNextState = inCloseParenState;
                beginCloseParenState.Handle = (c, tokenStream, queueu) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createOpenSqTokenState = new LexerState("create open sq token");
                createOpenSqTokenState.DefaultNextState = this.StartState;
                createOpenSqTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Open_Sq);
                    return false;
                };

            ILexerState inOpenSqState = new LexerState("in open sq");
                inOpenSqState.DefaultNextState = createOpenSqTokenState;
                inOpenSqState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind, CharKind.OPEN_SQ, c, queue);
                };

            ILexerState beginOpenSqState = new LexerState("begin open sq");
                beginOpenSqState.DefaultNextState = inOpenSqState;
                beginOpenSqState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createCloseSqTokenState = new LexerState("create close sq token");
                createCloseSqTokenState.DefaultNextState = this.StartState;
                createCloseSqTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.Close_Sq);
                    return false;
                };

            ILexerState inCloseSqState = new LexerState("in close sq");
                inCloseSqState.DefaultNextState = createCloseSqTokenState;
                inCloseSqState.Handle = (c, tokenStream, queue) => {
                    return this.HandleStorage((k, v) => k == v.Kind, CharKind.CLOSE_SQ, c, queue);
                };

            ILexerState beginCloseSqState = new LexerState("begin close sq");
                beginCloseSqState.DefaultNextState = inCloseSqState;
                beginCloseSqState.Handle = (c, tokenStream, queue) => {
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            this.StartState.AddTransitionState(CharKind.QUOTE, beginLiteralStringState);
            this.StartState.AddTransitionState(CharKind.ALPHA, beginAlphaState);
            this.StartState.AddTransitionState(CharKind.PUNCTUATION, beginPunctuationState);
            this.StartState.AddTransitionState(CharKind.DIGIT, beginLiteralNumberState);
            this.StartState.AddTransitionState(CharKind.SPACE, beginOneOrMoreSpaceState);
            this.StartState.AddTransitionState(CharKind.CARRAGERETURN, beginCarrageReturnState);
            this.StartState.AddTransitionState(CharKind.LINEFEED, beginLineFeedState);
            this.StartState.AddTransitionState(CharKind.UNKNOWN, beginUnknownCharacterState);
            this.StartState.AddTransitionState(CharKind.NULL, beginNULLState);
            this.StartState.AddTransitionState(CharKind.DASH, beginDashState);
            this.StartState.AddTransitionState(CharKind.DOT, beginDotState);
            this.StartState.AddTransitionState(CharKind.COMMA, beginCommaState);
            this.StartState.AddTransitionState(CharKind.OPEN_PAREN, beginOpenParenState);
            this.StartState.AddTransitionState(CharKind.CLOSE_PAREN, beginCloseParenState);
            this.StartState.AddTransitionState(CharKind.OPEN_SQ, beginOpenSqState);
            this.StartState.AddTransitionState(CharKind.CLOSE_SQ, beginCloseSqState);

        }
        private bool HandleStorage(Func<CharKind,ICharacter,bool> predicate, CharKind kind, ICharacter c, Queue<char> queue) {
            bool handled = false;
            if (predicate(kind,c)) {
                queue.Enqueue(c.Info);
                ++this.Position;
                handled = true;
            }
            return handled;
        }

        private void CreateToken(ITokenStream tokenStream, Queue<char> queue, TokenKind kind) {
            string item = QueueToString(queue);
            ILocation location = MemoryManager.New(this.Filename, this.Line, this.StartOfCurrentToken, item.Length);
            IToken token = MemoryManager.New(location, item, kind);
            tokenStream.Put(token);
        }

        public int StartOfCurrentToken { get; private set; }
        public int Line { get; private set; }
        public int Position { get; private set; }
        public string Filename { get; private set; }

        private static string QueueToString(Queue<char> q) {
            StringBuilder sb = new StringBuilder();
            while (q.Count > 0) {
                sb.Append(q.Dequeue());
            }
            q.Clear(); // insurance
            return sb.ToString();
        }

        public async Task Parse(ITokenStream tokenStream, ICharacterStream characterStream, string filename, int startLine, int startPosition) {
            this.Filename = filename;
            this.Line = startLine;
            this.Position = startPosition;

            Queue<char> q = new Queue<char>();
            ILexerState current = this.StartState;
            ILexerState next = this.StartState;
            bool handled = true;
            ICharacter c = null;
            while ((current != this.EndState) && (current != this.ErrorState)) {
                current = next;
                if (handled) {
                    c = await characterStream.Get();
                    handled = false;
                }
                handled = current.Handle(c, tokenStream, q);
                next = current.NextState(c.Kind);
            }
        }
    }
    public class Parser {

    }
    public class AutoComplete : IAutoComplete {
        private IList<IAutoCompleteItem> items = new List<IAutoCompleteItem>();
        private object lockObject = new object();
        public IEnumerable<IAutoCompleteItem> Items { get { return this.items; } }
        public void AddItem(IAutoCompleteItem item) {
            lock (this.lockObject) {
                if (!this.items.Contains(item)) this.items.Add(item);
            }
        }
    }
    public class AutoCompleteItem : IAutoCompleteItem {

        public string Value { get; set; }
    }
}
