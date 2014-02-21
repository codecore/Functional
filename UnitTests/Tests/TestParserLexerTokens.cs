using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestParserLexerTokens {
        [TestMethod]
        public async Task test_parser_lexer_numbers() {
            IAsyncTestCase test = new test_parser_lexer_token_numbers();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task test_parser_lexer_strings() {
            IAsyncTestCase test = new test_parser_lexer_token_strings();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
    }
}
