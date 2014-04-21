using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestJSONTokenizer {
        [TestMethod]
        public void test_json_tokenizer() {
            ISyncTestCase test = new test_json_tokenizer();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
