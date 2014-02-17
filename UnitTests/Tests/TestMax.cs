using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestMax {
        [TestMethod]
        public void max_double() {
            ISyncTestCase test = new max_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void max_float() {
            ISyncTestCase test = new max_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void max_int() {
            ISyncTestCase test = new max_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void max_long() {
            ISyncTestCase test = new max_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void max_short() {
            ISyncTestCase test = new max_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
