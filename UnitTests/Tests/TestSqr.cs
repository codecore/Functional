using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestSqr {
        [TestMethod]
        public void sqr_double() {
            ISyncTestCase test = new sqr_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_float() {
            ISyncTestCase test = new sqr_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_int() {
            ISyncTestCase test = new sqr_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_long() {
            ISyncTestCase test = new sqr_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sqr_short() {
            ISyncTestCase test = new sqr_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
