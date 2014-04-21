using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Contract.Editor;
using Functional.Language.Contract;
using Functional.Contracts.Utility;

using Functional.Language.Implimentation;
using Functional.Implementation;

namespace Functional.Language.Implimentation {
    [Export(typeof(ITokenizer))]
    public class Tokenizer : ITokenizer {
        private ITokenizerState StartState { get; set; }
        private ITokenizerState EndState { get; set; }
        private ITokenizerState ErrorState { get; set; }
        public void Initialize() {
            this.EndState = new TokenizerState("end");
            this.ErrorState = new TokenizerState("error");
            ErrorState.DefaultNextState = this.EndState;

            this.StartState = new TokenizerState("start");
            this.StartState.DefaultNextState = ErrorState;
            this.StartState.Handle = (c, tokenStream, queue) => false;

            ITokenizerState createLiteralStringTokenState = new TokenizerState("create literal string");
            createLiteralStringTokenState.DefaultNextState = this.StartState;
            createLiteralStringTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.LiteralString);
                return false;
            };

            ITokenizerState inEndQuoteState = new TokenizerState("in end quote");
            inEndQuoteState.DefaultNextState = createLiteralStringTokenState;
            inEndQuoteState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.QUOTE, c, queue);
            };

            ITokenizerState inLiteralStringState = new TokenizerState("in literal string");
            inLiteralStringState.DefaultNextState = inLiteralStringState;
            inLiteralStringState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k != v.Kind, CharKind.QUOTE, c, queue);
            };
            inLiteralStringState.AddTransitionState(CharKind.CARRAGERETURN, this.ErrorState); // unexpected \n
            inLiteralStringState.AddTransitionState(CharKind.NULL, this.ErrorState); // unexpected \0
            inLiteralStringState.AddTransitionState(CharKind.QUOTE, inEndQuoteState);

            ITokenizerState inStartQuoteState = new TokenizerState("in start quote");
            inStartQuoteState.DefaultNextState = inLiteralStringState;
            inStartQuoteState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.QUOTE, c, queue);
            };

            ITokenizerState beginLiteralStringState = new TokenizerState("begin literal string");
            beginLiteralStringState.DefaultNextState = inStartQuoteState;
            beginLiteralStringState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createPunctuationTokenState = new TokenizerState("create punctuation token");
            createPunctuationTokenState.DefaultNextState = this.StartState;
            createPunctuationTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Punctuation);
                return false;
            };

            ITokenizerState inPunctuationState = new TokenizerState("in punctuation");
            inPunctuationState.DefaultNextState = createPunctuationTokenState;
            inPunctuationState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.PUNCTUATION, c, queue);
            };

            ITokenizerState beginPunctuationState = new TokenizerState("begin punctuation state");
            beginPunctuationState.DefaultNextState = inPunctuationState;
            beginPunctuationState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createFractionTokenState = new TokenizerState("create fraction token");
            createFractionTokenState.DefaultNextState = this.StartState;
            createFractionTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.LiteralFloat);
                return false;
            };

            ITokenizerState inFractionState = new TokenizerState("in fraction");
            inFractionState.DefaultNextState = createFractionTokenState;
            inFractionState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.DIGIT, c, queue);
            };
            inFractionState.AddTransitionState(CharKind.DIGIT, inFractionState);

            ITokenizerState beginFractionState = new TokenizerState("begin fraction");
            beginFractionState.DefaultNextState = inFractionState;
            beginFractionState.Handle = (c, tokenStream, queue) => false;

            ITokenizerState inDecimalPointState = new TokenizerState("in decimal point");
            inDecimalPointState.DefaultNextState = this.ErrorState; // there must be a number after the decimal point
            inDecimalPointState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.DOT, c, queue);
            };
            inDecimalPointState.AddTransitionState(CharKind.DOT, beginFractionState); // hack
            inDecimalPointState.AddTransitionState(CharKind.DIGIT, beginFractionState);

            ITokenizerState beginDecimalPointState = new TokenizerState("begin decimal point");
            beginDecimalPointState.DefaultNextState = inDecimalPointState;
            beginDecimalPointState.Handle = (c, tokenStream, queue) => {
                return false;
            };

            ITokenizerState createLiteralIntegerTokenState = new TokenizerState("create literal integer token");
            createLiteralIntegerTokenState.DefaultNextState = this.StartState;
            createLiteralIntegerTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.LiteralInteger);
                return false;
            };

            ITokenizerState inLiteralNumberState = new TokenizerState("in number");
            inLiteralNumberState.DefaultNextState = createLiteralIntegerTokenState;
            inLiteralNumberState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.DIGIT, c, queue);
            };
            inLiteralNumberState.AddTransitionState(CharKind.DIGIT, inLiteralNumberState);
            inLiteralNumberState.AddTransitionState(CharKind.DOT, beginDecimalPointState);

            ITokenizerState beginLiteralNumberState = new TokenizerState("begin literal number state");
            beginLiteralNumberState.DefaultNextState = inLiteralNumberState;
            beginLiteralNumberState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createOneOrMoreSpaceTokenState = new TokenizerState("create one or more space token");
            createOneOrMoreSpaceTokenState.DefaultNextState = this.StartState;
            createOneOrMoreSpaceTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.OneOrMoreSpace);
                return false;
            };

            ITokenizerState inOneOrMoreSpaceState = new TokenizerState("in one or more space");
            inOneOrMoreSpaceState.DefaultNextState = createOneOrMoreSpaceTokenState;
            inOneOrMoreSpaceState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.SPACE, c, queue);
            };
            inOneOrMoreSpaceState.AddTransitionState(CharKind.SPACE, inOneOrMoreSpaceState);

            ITokenizerState beginOneOrMoreSpaceState = new TokenizerState("begin one or more space");
            beginOneOrMoreSpaceState.DefaultNextState = inOneOrMoreSpaceState;
            beginOneOrMoreSpaceState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createLineFeedTokenState = new TokenizerState("create line feed token");
            createLineFeedTokenState.DefaultNextState = this.StartState;
            createLineFeedTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.LineFeed);
                return false;
            };

            ITokenizerState inLineFeedState = new TokenizerState("in line feed");
            inLineFeedState.DefaultNextState = createLineFeedTokenState;
            inLineFeedState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.LINEFEED, c, queue);
            };

            ITokenizerState beginLineFeedState = new TokenizerState("begin line feed state");
            beginLineFeedState.DefaultNextState = inLineFeedState;
            beginLineFeedState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createCarrageReturnTokenState = new TokenizerState("create carrage return token");
            createCarrageReturnTokenState.DefaultNextState = this.StartState;
            createCarrageReturnTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.CarrageReturn);
                ++this.Line;
                this.Position = 0;
                return false;
            };

            ITokenizerState inCarrageReturnState = new TokenizerState("in carrage return");
            inCarrageReturnState.DefaultNextState = createCarrageReturnTokenState;
            inCarrageReturnState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.CARRAGERETURN, c, queue);
            };

            ITokenizerState beginCarrageReturnState = new TokenizerState("begin carrage return");
            beginCarrageReturnState.DefaultNextState = inCarrageReturnState;
            beginCarrageReturnState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createNULLTokenState = new TokenizerState("create NULL token");
            createNULLTokenState.DefaultNextState = this.EndState; // we go to DONE
            createNULLTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.NULL);
                return false;
            };

            ITokenizerState inNULLState = new TokenizerState("in NULL");
            inNULLState.DefaultNextState = createNULLTokenState;
            inNULLState.Handle = (c, tokenStream, queue) => {
                bool throwaway = this.HandleStorage((k, v) => k == v.Kind, CharKind.NULL, c, queue);
                return false; // always return false once we get a null
            };

            ITokenizerState beginNULLState = new TokenizerState("begin NULL");
            beginNULLState.DefaultNextState = inNULLState;
            beginNULLState.Handle = (c, tokenStream, queueu) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createAlphaTokenState = new TokenizerState("create alpha token");
            createAlphaTokenState.DefaultNextState = this.StartState;
            createAlphaTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.UnquotedWord);
                return false;
            };

            ITokenizerState inAlphaState = new TokenizerState("in alpha");
            inAlphaState.DefaultNextState = createAlphaTokenState;
            inAlphaState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.ALPHA, c, queue);
            };
            inAlphaState.AddTransitionState(CharKind.ALPHA, inAlphaState);

            ITokenizerState beginAlphaState = new TokenizerState("begin alpha");
            beginAlphaState.DefaultNextState = inAlphaState;
            beginAlphaState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createUnknownCharacterTokenState = new TokenizerState("create unknown character token");
            createUnknownCharacterTokenState.DefaultNextState = this.StartState;
            createUnknownCharacterTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Unknown);
                return false;
            };

            ITokenizerState inUnknownCharacterState = new TokenizerState("in unknown character");
            inUnknownCharacterState.DefaultNextState = createUnknownCharacterTokenState;
            inUnknownCharacterState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.UNKNOWN, c, queue);
            };
            inUnknownCharacterState.AddTransitionState(CharKind.UNKNOWN, inUnknownCharacterState);

            ITokenizerState beginUnknownCharacterState = new TokenizerState("begin unknown character");
            beginUnknownCharacterState.DefaultNextState = inUnknownCharacterState;
            beginUnknownCharacterState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createDotTokenState = new TokenizerState("create dot");
            createDotTokenState.DefaultNextState = this.StartState;
            createDotTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Dot);
                return false;
            };

            ITokenizerState inDotState = new TokenizerState("in dot");
            inDotState.DefaultNextState = createDotTokenState;
            inDotState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.DOT, c, queue);
            };

            ITokenizerState beginDotState = new TokenizerState("begin dot");
            beginDotState.DefaultNextState = inDotState;
            beginDotState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createDashTokenState = new TokenizerState("create dash");
            createDashTokenState.DefaultNextState = this.StartState;
            createDashTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Dash);
                return false;
            };

            ITokenizerState decideDashOrNegativeState = new TokenizerState("decide");
            decideDashOrNegativeState.DefaultNextState = createDashTokenState;
            decideDashOrNegativeState.Handle = (c, tokenStream, queue) => false;
            decideDashOrNegativeState.AddTransitionState(CharKind.DIGIT, inLiteralNumberState);

            ITokenizerState inDashState = new TokenizerState("in dash");
            inDashState.DefaultNextState = decideDashOrNegativeState;
            inDashState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.DASH, c, queue);
            };

            ITokenizerState beginDashState = new TokenizerState("begin dash");
            beginDashState.DefaultNextState = inDashState;
            beginDashState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createCommaTokenState = new TokenizerState("create comma"); // candy to help downstream language parser
            createCommaTokenState.DefaultNextState = this.StartState;
            createCommaTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Comma);
                return false;
            };

            ITokenizerState inCommaState = new TokenizerState("in comma");
            inCommaState.DefaultNextState = createCommaTokenState;
            inCommaState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.COMMA, c, queue);
            };

            ITokenizerState beginCommaState = new TokenizerState("begin comma");
            beginCommaState.DefaultNextState = inCommaState;
            beginCommaState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createOpenParenTokenState = new TokenizerState("create open paren token");
            createOpenParenTokenState.DefaultNextState = this.StartState;
            createOpenParenTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Open_Paren);
                return false;
            };

            ITokenizerState inOpenParenState = new TokenizerState("in open paren");
            inOpenParenState.DefaultNextState = createOpenParenTokenState;
            inOpenParenState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.OPEN_PAREN, c, queue);
            };

            ITokenizerState beginOpenParenState = new TokenizerState("begin open paren");
            beginOpenParenState.DefaultNextState = inOpenParenState;
            beginOpenParenState.Handle = (c, tokenStream, queueu) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createCloseParenTokenState = new TokenizerState("create close paren token");
            createCloseParenTokenState.DefaultNextState = this.StartState;
            createCloseParenTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Close_Paren);
                return false;
            };

            ITokenizerState inCloseParenState = new TokenizerState("in close paren");
            inCloseParenState.DefaultNextState = createCloseParenTokenState;
            inCloseParenState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.CLOSE_PAREN, c, queue);
            };

            ITokenizerState beginCloseParenState = new TokenizerState("begin close paren");
            beginCloseParenState.DefaultNextState = inCloseParenState;
            beginCloseParenState.Handle = (c, tokenStream, queueu) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createOpenSqTokenState = new TokenizerState("create open sq token");
            createOpenSqTokenState.DefaultNextState = this.StartState;
            createOpenSqTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Open_Sq);
                return false;
            };

            ITokenizerState inOpenSqState = new TokenizerState("in open sq");
            inOpenSqState.DefaultNextState = createOpenSqTokenState;
            inOpenSqState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.OPEN_SQ, c, queue);
            };

            ITokenizerState beginOpenSqState = new TokenizerState("begin open sq");
            beginOpenSqState.DefaultNextState = inOpenSqState;
            beginOpenSqState.Handle = (c, tokenStream, queue) => {
                this.StartOfCurrentToken = this.Position;
                return false;
            };

            ITokenizerState createCloseSqTokenState = new TokenizerState("create close sq token");
            createCloseSqTokenState.DefaultNextState = this.StartState;
            createCloseSqTokenState.Handle = (c, tokenStream, queue) => {
                this.CreateToken(tokenStream, queue, TokenKind.Close_Sq);
                return false;
            };

            ITokenizerState inCloseSqState = new TokenizerState("in close sq");
            inCloseSqState.DefaultNextState = createCloseSqTokenState;
            inCloseSqState.Handle = (c, tokenStream, queue) => {
                return this.HandleStorage((k, v) => k == v.Kind, CharKind.CLOSE_SQ, c, queue);
            };

            ITokenizerState beginCloseSqState = new TokenizerState("begin close sq");
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
        private bool HandleStorage(Func<CharKind, ICharacter, bool> predicate, CharKind kind, ICharacter c, Queue<char> queue) {
            bool handled = false;
            if (predicate(kind, c)) {
                queue.Enqueue(c.Info);
                ++this.Position;
                handled = true;
            }
            return handled;
        }

        private void CreateToken(IStream<IToken> tokenStream, Queue<char> queue, TokenKind kind) {
            string item = QueueToString(queue);
            ILocation location = Location.Create(this.Filename, this.Line, this.StartOfCurrentToken, item.Length);
            IToken token = Token.Create(location, item, kind);
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

        public async Task Tokenize(IStream<IToken> tokenStream, ICharacterStream characterStream, string filename, int startLine, int startPosition) {
            this.Filename = filename;
            this.Line = startLine;
            this.Position = startPosition;

            Queue<char> q = new Queue<char>();
            ITokenizerState current = this.StartState;
            ITokenizerState next = this.StartState;
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
}
