using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLt {
        [TestMethod]
        public void lt_double() {
            ITestCase test = new lt_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_float() {
            ITestCase test = new lt_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_int() {
            ITestCase test = new lt_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_long() {
            ITestCase test = new lt_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_short() {
            ITestCase test = new lt_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
