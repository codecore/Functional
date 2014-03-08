using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestMin {
        [TestMethod]
        public void min_double() {
            ISyncTestCase test = new min_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_float() {
            ISyncTestCase test = new min_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_int() {
            ISyncTestCase test = new min_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_long() {
            ISyncTestCase test = new min_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void min_short() {
            ISyncTestCase test = new min_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
