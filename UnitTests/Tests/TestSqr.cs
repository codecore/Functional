using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestSqr {
        [TestMethod]
        public void sqr_double() {
            ITestCase test = new sqr_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_float() {
            ITestCase test = new sqr_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_int() {
            ITestCase test = new sqr_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_long() {
            ITestCase test = new sqr_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_short() {
            ITestCase test = new sqr_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
