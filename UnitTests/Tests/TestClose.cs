using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestClose {
        [TestMethod]
        public void close_double() {
            ITestCase test = new close_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void close_float() {
            ITestCase test = new close_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_and() {
            ITestCase test = new bool_and();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
