using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestBool {
        [TestMethod]
        public void bool_and() {
            ITestCase test = new bool_and();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_eqv() {
            ITestCase test = new bool_eqv();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_or() {
            ITestCase test = new bool_or();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_xor() {
            ITestCase test = new bool_xor();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_And() {
            ITestCase test = new bool_And();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_Or() {
            ITestCase test = new bool_Or();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
