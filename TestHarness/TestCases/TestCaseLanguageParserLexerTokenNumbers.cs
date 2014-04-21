using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
using Functional.Contracts.Utility;
using Functional.Utility;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {

    [Export(typeof(IAsyncTestCase))]
    public class test_parser_tokenizer_token_numbers : IAsyncTestCase {
        private const string _Name = "test parser tokenizer token numbers";
        private const string _Description = "tokenize string in to correct tokens.";
        public string TestFile { get { return "TestCaseLanguageParserLexerTokenNumbers.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IInputStream stream = new InputStreamMock();//" 2,9.0-77.4"
            await stream.Initialize(" 2,9.0-77.4");
            ICharacterStream cStream = new CharacterStream();
            cStream.Initialize(stream);

            IStream<IToken> tokenStream = new Stream<IToken>();
            Queue<char> word = new Queue<char>();

            ITokenizer tokenizer = new Tokenizer();
            tokenizer.Initialize();
            await tokenizer.Tokenize(tokenStream, cStream, "filename", 0, 0);

            IToken token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.OneOrMoreSpace);
            
            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.LiteralInteger) && (token.Info == "2"));

            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.Comma) && (token.Info == ","));

            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.LiteralFloat) && (token.Info == "9.0"));

            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.LiteralFloat) && (token.Info == "-77.4"));

            stream.Dispose();
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_parser_tokenizer_token_numbers() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_OneOrMoreSpace);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_OneOrMoreSpace_1_Space);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralInteger);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_Comma);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralFloat);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralFloat_Negative);


            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_OneOrMoreSpace);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_OneOrMoreSpace_1_Space);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralInteger);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_Comma);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralFloat);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralFloat_Negative);
        }
    }
}
