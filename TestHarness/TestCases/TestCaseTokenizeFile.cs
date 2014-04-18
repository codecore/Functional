
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
    public class test_file_tokenizer : IAsyncTestCase {
        private const string _Name = "test file tokenizer";
        private const string _Description = "parse file to import correct tokens.";
        public string TestFile { get { return "TestCaseTokenizerFile.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IParser parser = new ParserFile("TestFiles\\TestTokenizerTokenKinds.txt");
            await parser.Initialize();
            ITokenStream tokenStream = await parser.Tokenize();

            /*
124.7 text
:+99
THIS SHOULD create (float)(space)(unqstring)(cr)(lf)(punc)(punc)(int)(NULL)
             * */


            IToken token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.LiteralFloat);

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.OneOrMoreSpace);

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.UnquotedWord);

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.CarrageReturn);

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.LineFeed);

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.Punctuation); // :

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.Punctuation); // +

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.LiteralInteger); // 99

            token = tokenStream.Get();
            result = result && (token.Kind == TokenKind.NULL); // EOF

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
        public test_file_tokenizer() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Tokenizer);
            this.feature.Add(TestCoverage.Lang_Tokenizer_File);


            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Tokenizer);
            this.coverage.Add(TestCoverage.Lang_Tokenizer_File);
        }
    }
}
