using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional.Implementation;

using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestAdd {
        [TestMethod]
        public void add_double() {
            ISyncTestCase test = new add_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_float() {
            ISyncTestCase test = new add_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_int() {
            ISyncTestCase test = new add_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_long() {
            ISyncTestCase test = new add_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_short() {
            ISyncTestCase test = new add_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void add_string() {
            ISyncTestCase test = new add_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
