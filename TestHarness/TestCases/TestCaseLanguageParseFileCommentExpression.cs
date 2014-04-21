using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Contracts.Utility;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
using Functional.Language.Contract.Core;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {

    [Export(typeof(IAsyncTestCase))]
    public class test_parser_file_parser_expression_comment : IAsyncTestCase {
        private const string _Name = "test parser file parser expression comment";
        private const string _Description = "parse file to create a comment expression.";
        public string TestFile { get { return "TestCaseLanguageParserFileCommentExpression.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IParser parser = new ParserFile("TestFiles\\TestParseCommentExpression.func.txt");
            await parser.Initialize();
            IStream<IToken> tokenStream = await parser.Tokenize();

            
            IToken token = tokenStream.Get();
            while(
                (!((token.Kind == TokenKind.UnquotedWord) && (token.Info == "comment"))) &&
                (!(token.Kind == TokenKind.NULL))) {
                token = tokenStream.Get();
            }
            if (token.Kind != TokenKind.NULL) {
                tokenStream.Push(token);
                CommentExpressionParser commentExpressionParser = new CommentExpressionParser();
                IParseError parseError = ParseError.Create();
                IExpression ex = commentExpressionParser.Parse(null, tokenStream,ref parseError);
                token = F.first<IToken>(ex.Tokens);
                result = result && (token.Kind == TokenKind.UnquotedWord) && (token.Info == "comment");
                // TODO test for end of comment
                // TODO get the following comment
            }
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
        public test_parser_file_parser_expression_comment() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Expression);
            this.feature.Add(TestCoverage.Lang_Parser_Expression_Comment);


            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Expression);
            this.coverage.Add(TestCoverage.Lang_Parser_Expression_Comment);
        }
    }
}
