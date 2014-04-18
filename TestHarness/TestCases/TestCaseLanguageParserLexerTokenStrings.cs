﻿using System;
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
    public class test_parser_tokenizer_token_strings : IAsyncTestCase {
        private const string _Name = "test parser tokeninzer token strings";
        private const string _Description = "test that tokenizer can create string tokens";
        public string TestFile { get { return "TestCaseLanguageParserLexerTokenParser.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IInputStream stream = new InputStreamMock();
            await stream.Initialize("\"literal string\"regularstring");
            ICharacterStream cStream = new CharacterStream();
            cStream.Initialize(stream);

            ITokenStream tokenStream = new TokenStream();
            Queue<char> word = new Queue<char>();

            ITokenizer tokenizer = new Tokenizer();
            tokenizer.Initialize();
            await tokenizer.Tokenize(tokenStream, cStream, "filename", 0, 0);
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
        public test_parser_tokenizer_token_strings() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralString);
            this.feature.Add(TestCoverage.Lang_Parser_Tokenizer_Token_UnquotedWord);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_LiteralString);
            this.coverage.Add(TestCoverage.Lang_Parser_Tokenizer_Token_UnquotedWord);
        }
    }
}
