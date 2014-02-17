using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestSub {
        [TestMethod]
        public void sub_double() {
            ISyncTestCase test = new sub_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sub_float() {
            ISyncTestCase test = new sub_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sub_int() {
            ISyncTestCase test = new sub_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sub_long() {
            ISyncTestCase test = new sub_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void sub_short() {
            ISyncTestCase test = new sub_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
