using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Contract.Editor;
using Functional.Language.Contract;
using Functional.Language.Contract.Core;
using Functional.Language.Implimentation;
using Functional.Implementation;

namespace Functional.Language.Implimentation {

    [Export(typeof(IParser))]
    public class ParserFile : IParser {
        [ImportMany(typeof(IExpressionParser))]
        private IEnumerable<IExpressionParser> parsers;
        public IEnumerable<IExpressionParser> Parsers { get { return this.parsers; } }
        private IInputStream inputStream = null;
        public IParserContext Context { get; private set; }
        public void Dispose() {
            if (null != this.inputStream) this.inputStream.Dispose();
            this.inputStream = null;
        }
        private string filename;
        public ParserFile(string filename) {
            this.filename = filename;
            this.Context = ParserContext.Create();
        }
        public async Task Initialize() {
            this.inputStream = new InputStreamFile();
            await this.inputStream.Initialize(this.filename);
        }
        public async Task<ITokenStream> Tokenize() {
            ICharacterStream characterStream = new CharacterStream();
            characterStream.Initialize(this.inputStream);
            ITokenStream tokenStream = new TokenStream();
            Queue<char> word = new Queue<char>();
            ITokenizer tokenizer = new Tokenizer();
            tokenizer.Initialize();
            await tokenizer.Tokenize(tokenStream, characterStream, this.filename, 0, 0);
            return tokenStream;
        }
        public IExpression Parse(ITokenStream tokenStream, ref IParseError parseError) {
            IExpression result = null;
            IToken token = tokenStream.Get();
            while ((token.Kind != TokenKind.UnquotedWord) || (token.Kind != TokenKind.NULL)) {
                token = tokenStream.Get();
            }
            // two options here.
            // 1. Give all each of the expression parsers a shot at the token.
            //    we stop once one takes it (COR pattern)
            // 2. Parser searches all the expression parsers keywords, anf once it finds a match
            //     it dispatches that one.
            // We impliment both.
            if (token.Kind != TokenKind.NULL) {
                tokenStream.Push(token);
                result = this.parseWithFirstThatWillTakeIt(tokenStream, ref parseError);
                // result = this.parseWithSelectedExpressionParser(ITokenStream tokenStream, ref IParseError parseError);
            }
            return result;
        }
        // COR pattern
        private IExpression parseWithSelectedExpressionParser(ITokenStream tokenStream, ref IParseError parseError) {
            IExpression result = null;
            IToken token = tokenStream.Get();
            if (token.Kind != TokenKind.NULL) {
                IEnumerable<IExpressionParser> potentialExpressionParsers = F.filter<IExpressionParser>(this.Parsers, (p) => p.Keyword == token.Info);
                int count = F.count<IExpressionParser>(potentialExpressionParsers);
                if (0 < count) {
                    IExpressionParser chosenExpressionParser = F.first<IExpressionParser>(potentialExpressionParsers);
                    tokenStream.Push(token);
                    result = chosenExpressionParser.Parse(this, tokenStream, ref parseError);
                } else {
                    // TODO ParseError found no ExpressionParsers for the token
                }
            } // else TODO return ParseError unexpected NULL (EOF)
            return result;
        }
        private IExpression parseWithFirstThatWillTakeIt(ITokenStream tokenStream, ref IParseError parseError) {
            IExpression result = null;
            foreach (IExpressionParser parser in this.Parsers) {
                result = parser.Parse(this, tokenStream, ref parseError);
                if (null != result) break;
            }
            return result;
        }
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
