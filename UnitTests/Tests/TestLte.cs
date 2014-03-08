using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLte {
        [TestMethod]
        public void lte_int() {
            ISyncTestCase test = new lte_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lte_long() {
            ISyncTestCase test = new lte_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lte_short() {
            ISyncTestCase test = new lte_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
