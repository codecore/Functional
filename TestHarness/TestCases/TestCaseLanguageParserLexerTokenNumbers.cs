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
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {

    [Export(typeof(IAsyncTestCase))]
    public class test_parser_lexer_token_numbers : IAsyncTestCase {
        private const string _Name = "test parser lexer token numbers";
        private const string _Description = "parse string in to correct tokens.";
        public string TestFile { get { return "TestCaseLanguageToken.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IInputStream inputStream = new InputStreamMock(1, " 2,9.0-77.4");
            IGetChar getChar = new GetChar();
            ICharacterStream characterStream = new CharacterStream();
            getChar.Initialize(inputStream);
            characterStream.Initialize(getChar);

            ITokenStream tokenStream = new TokenStream();
            Queue<char> word = new Queue<char>();

            ILexer lexer = new Lexer();
            lexer.Initialize();
            await lexer.Parse(tokenStream, characterStream, "filename", 0, 0);

            IToken token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.OneOrMoreSpace);
            MemoryManager.Delete(token);
            
            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.LiteralInteger) && (token.Info == "2"));
            MemoryManager.Delete(token);

            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.Comma) && (token.Info == ","));
            MemoryManager.Delete(token);

            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.LiteralFloat) && (token.Info == "9.0"));
            MemoryManager.Delete(token);

            token = tokenStream.Get();
            result = result && ((token.Kind == TokenKind.LiteralFloat) && (token.Info == "-77.4"));
            MemoryManager.Delete(token);

            MemoryManager.FreeMemory();
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_parser_lexer_token_numbers() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token_OneOrMoreSpace);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token_OneOrMoreSpace_OneSpace);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token_LiteralInteger);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token_Comma);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token_LiteralFloat);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer_Token_LiteralFloat_Negative);


            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token_OneOrMoreSpace);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token_OneOrMoreSpace_OneSpace);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token_LiteralInteger);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token_Comma);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token_LiteralFloat);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer_Token_LiteralFloat_Negative);
        }
    }
}
