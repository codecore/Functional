using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestRange {
        [TestMethod]
        public void range_start_end() {
            ISyncTestCase test = new range_start_end();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_start_end_reverse() {
            ISyncTestCase test = new range_start_end_reverse();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_end() {
            ISyncTestCase test = new range_end();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_start_end_step() {
            ISyncTestCase test = new range_start_end_step();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_start_end_step_descending() {
            ISyncTestCase test = new range_start_end_step_descending();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
