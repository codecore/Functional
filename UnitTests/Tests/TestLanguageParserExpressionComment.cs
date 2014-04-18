using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageParseExpressionComment {
        [TestMethod]
        public async Task test_parser_file_parser_expression_comment() {
            IAsyncTestCase test = new test_parser_file_parser_expression_comment();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
    }
}