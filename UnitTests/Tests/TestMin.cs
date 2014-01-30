using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestMin {
        [TestMethod]
        public void min_double() {
            ITestCase test = new min_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_float() {
            ITestCase test = new min_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_int() {
            ITestCase test = new min_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_long() {
            ITestCase test = new min_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_short() {
            ITestCase test = new min_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
