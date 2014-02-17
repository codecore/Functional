using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageCharacter {
        [TestMethod]
        public void test_character() {
            ISyncTestCase test = new test_character();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
