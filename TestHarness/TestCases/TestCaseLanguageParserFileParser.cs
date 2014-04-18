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
    public class test_parser_file_parser : IAsyncTestCase {
        private const string _Name = "test file parser";
        private const string _Description = "parse file to import correct tokens.";
        public string TestFile { get { return "TestCaseLanguageParserFileParser.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IParser parser = new ParserFile("TestFiles\\TestParseNumberExpressions.func.txt");
            await parser.Initialize();
            ITokenStream tokenStream = await parser.Tokenize();

            IToken token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.UnquotedWord);

            parser.Dispose();
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_parser_file_parser() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Parser_ParseFile);


            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Parser_ParseFile);
        }
    }
}