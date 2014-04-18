using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageParserTokenizerTokens {
        [TestMethod]
        public async Task test_parser_tokenizer_numbers() {
            IAsyncTestCase test = new test_parser_tokenizer_token_numbers();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task test_parser_tokenizer_token_strings() {
            IAsyncTestCase test = new test_parser_tokenizer_token_strings();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
    }
}
