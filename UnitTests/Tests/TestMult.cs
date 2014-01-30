using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestMult {
        [TestMethod]
        public void mult_double() {
            ITestCase test = new mult_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_float() {
            ITestCase test = new mult_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_int() {
            ITestCase test = new mult_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_long() {
            ITestCase test = new mult_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_short() {
            ITestCase test = new mult_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
