using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageParseFileParser {
        [TestMethod]
        public async Task test_parser_file_parser() {
            IAsyncTestCase test = new test_parser_file_parser();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
    }
}
