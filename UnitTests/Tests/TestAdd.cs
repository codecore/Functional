using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestAdd {
        [TestMethod]
        public void add_double() {
            ITestCase test = new add_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_float() {
            ITestCase test = new add_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_int() {
            ITestCase test = new add_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_long() {
            ITestCase test = new add_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_short() {
            ITestCase test = new add_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_string() {
            ITestCase test = new add_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
