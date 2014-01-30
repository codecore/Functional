using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLte {
        [TestMethod]
        public void lte_int() {
            ITestCase test = new lte_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lte_long() {
            ITestCase test = new lte_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void lte_short() {
            ITestCase test = new lte_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
