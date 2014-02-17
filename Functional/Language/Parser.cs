using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;

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
                
            ILexerState endLiteralStringState = new LexerState("end literal string");
                endLiteralStringState.DefaultNextState = createLiteralStringTokenState;
                endLiteralStringState.Handle = (c, tokenStream, queue) => {
                    ++this.Position; // still a bug here
                    return true; // we eat the end quote
                };
                
            ILexerState inLiteralStringState = new LexerState("in literal string");
                inLiteralStringState.DefaultNextState = inLiteralStringState;
                inLiteralStringState.Handle = (c, tokenStream, queue) => {
                    bool handled = false;
                    if (c.Kind != CharKind.QUOTE) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };
                inLiteralStringState.AddTransitionState(CharKind.CARRAGERETURN, this.ErrorState); // unexpected \n
                inLiteralStringState.AddTransitionState(CharKind.NULL, this.ErrorState); // unexpected \0
                inLiteralStringState.AddTransitionState(CharKind.QUOTE, endLiteralStringState);

            ILexerState beginLiteralStringState = new LexerState("begin literal string");
                beginLiteralStringState.DefaultNextState = inLiteralStringState;
                beginLiteralStringState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.QUOTE, c);
                    ++this.Position; // bug here
                    return true; // we eat the open quote
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
                    bool handled = false;
                    if (c.Kind == CharKind.PUNCTUATION) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };

            ILexerState beginPunctuationState = new LexerState("begin punctuation state");
                beginPunctuationState.DefaultNextState = inPunctuationState;
                beginPunctuationState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.PUNCTUATION, c);
                    this.StartOfCurrentToken = this.Position;
                    return false;
                };

            ILexerState createLiteralNumberTokenState = new LexerState("create literal number token");
                createLiteralNumberTokenState.DefaultNextState = this.StartState;
                createLiteralNumberTokenState.Handle = (c, tokenStream, queue) => {
                    this.CreateToken(tokenStream, queue, TokenKind.LiteralNumber);
                    return false;
                };

            ILexerState inLiteralNumberState = new LexerState("in number");
                inLiteralNumberState.DefaultNextState = createLiteralNumberTokenState;
                inLiteralNumberState.Handle = (c, tokenStream, queue) => {
                    bool handled = false;
                    if (c.Kind == CharKind.DIGIT) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                     }
                     return handled;
                };
                inLiteralNumberState.AddTransitionState(CharKind.DIGIT, inLiteralNumberState);

            ILexerState beginLiteralNumberState = new LexerState("begin literal number state");
                beginLiteralNumberState.DefaultNextState = inLiteralNumberState;
                beginLiteralNumberState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.DIGIT, c);
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
                    bool handled = false;
                    if (c.Kind == CharKind.SPACE) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };
                inOneOrMoreSpaceState.AddTransitionState(CharKind.SPACE, inOneOrMoreSpaceState);

            ILexerState beginOneOrMoreSpaceState = new LexerState("begine one or more space");
                beginOneOrMoreSpaceState.DefaultNextState = inOneOrMoreSpaceState;
                beginOneOrMoreSpaceState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.SPACE, c);
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
                    bool handled = false;
                    if (c.Kind == CharKind.LINEFEED) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };

            ILexerState beginLineFeedState = new LexerState("begin line feed state");
                beginLineFeedState.DefaultNextState = inLineFeedState;
                beginLineFeedState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.LINEFEED, c);
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
                    bool handled = false;
                    if (c.Kind == CharKind.CARRAGERETURN) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };
            ILexerState beginCarrageReturnState = new LexerState("begin carrage return");
                beginCarrageReturnState.DefaultNextState = inCarrageReturnState;
                beginCarrageReturnState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.CARRAGERETURN, c);
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
                    bool handled = false;
                    if (c.Kind == CharKind.NULL) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = false; // once we get a null, we don't ask for more
                    }
                    return handled;
                };

            ILexerState beginNULLState = new LexerState("begin NULL");
                beginNULLState.DefaultNextState = inNULLState;
                beginNULLState.Handle = (c, tokenStream, queueu) => {
                    this.verifyKind(CharKind.NULL, c);
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
                    bool handled = false;
                    if (c.Kind == CharKind.ALPHA) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };
                inAlphaState.AddTransitionState(CharKind.ALPHA, inAlphaState);

            ILexerState beginAlphaState = new LexerState("begin alpha");
                beginAlphaState.DefaultNextState = inAlphaState;
                beginAlphaState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.ALPHA, c);
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
                    bool handled = false;
                    if (c.Kind == CharKind.UNKNOWN) {
                        queue.Enqueue(c.Info);
                        ++this.Position;
                        handled = true;
                    }
                    return handled;
                };
                inUnknownCharacterState.AddTransitionState(CharKind.UNKNOWN, inUnknownCharacterState);

            ILexerState beginUnknownCharacterState = new LexerState("begin unknown character");
                beginUnknownCharacterState.DefaultNextState = inUnknownCharacterState;
                beginUnknownCharacterState.Handle = (c, tokenStream, queue) => {
                    this.verifyKind(CharKind.UNKNOWN, c);
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

        }
        private void verifyKind(CharKind expected, ICharacter c) {
            if (c.Kind != expected) throw new Exception(String.Format("lexer incorrectly catagorized {0} as {1} rather than {2}", c.Info,c.Kind.ToString(),expected.ToString()));
            
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
}
