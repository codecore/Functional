using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestNeq {
        [TestMethod]
        public void neq_bool() {
            ISyncTestCase test = new neq_bool();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void neq_char() {
            ISyncTestCase test = new neq_char();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void neq_int() {
            ISyncTestCase test = new neq_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void neq_long() {
            ISyncTestCase test = new neq_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void neq_short() {
            ISyncTestCase test = new neq_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void neq_string() {
            ISyncTestCase test = new neq_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
