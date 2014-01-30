using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestGte {
        [TestMethod]
        public void gte_int() {
            ITestCase test = new gte_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gte_long() {
            ITestCase test = new gte_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gte_short() {
            ITestCase test = new gte_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
