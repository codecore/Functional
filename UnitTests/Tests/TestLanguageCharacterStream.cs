using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageCharacterStream {
        [TestMethod]
        public async Task test_character_stream() {
            IAsyncTestCase test = new test_character_stream();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
    }
}
