using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestMult {
        [TestMethod]
        public void mult_double() {
            ISyncTestCase test = new mult_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_float() {
            ISyncTestCase test = new mult_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_int() {
            ISyncTestCase test = new mult_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_long() {
            ISyncTestCase test = new mult_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void mult_short() {
            ISyncTestCase test = new mult_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
