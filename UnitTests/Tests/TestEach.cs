using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestEach {
        [TestMethod]
        public void test_each() {
            ITestCase test = new test_each();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
