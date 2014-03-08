using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestGte {
        [TestMethod]
        public void gte_int() {
            ISyncTestCase test = new gte_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gte_long() {
            ISyncTestCase test = new gte_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gte_short() {
            ISyncTestCase test = new gte_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
