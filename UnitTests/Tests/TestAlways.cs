using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestAlways {
        [TestMethod]
        public void always_function_true() {
            ISyncTestCase test = new always_functioin_true();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void always_function_false() {
            ISyncTestCase test = new always_functioin_false();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void always_true() {
            ISyncTestCase test = new always_true();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void always_false() {
            ISyncTestCase test = new always_false();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
