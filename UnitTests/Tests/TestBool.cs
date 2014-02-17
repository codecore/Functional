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
            ISyncTestCase test = new bool_and();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_eqv() {
            ISyncTestCase test = new bool_eqv();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_or() {
            ISyncTestCase test = new bool_or();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_xor() {
            ISyncTestCase test = new bool_xor();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_And() {
            ISyncTestCase test = new bool_And();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void bool_Or() {
            ISyncTestCase test = new bool_Or();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
