using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestGt {
        [TestMethod]
        public void gt_double() {
            ISyncTestCase test = new gt_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gt_float() {
            ISyncTestCase test = new gt_float();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gt_int() {
            ISyncTestCase test = new gt_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gt_long() {
            ISyncTestCase test = new gt_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gt_short() {
            ISyncTestCase test = new gt_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
