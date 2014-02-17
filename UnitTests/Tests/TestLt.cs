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
            ISyncTestCase test = new lt_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_float() {
            ISyncTestCase test = new lt_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_int() {
            ISyncTestCase test = new lt_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_long() {
            ISyncTestCase test = new lt_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lt_short() {
            ISyncTestCase test = new lt_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
