using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestRange {
        [TestMethod]
        public void range_start_end() {
            ITestCase test = new range_start_end();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_start_end_reverse() {
            ITestCase test = new range_start_end_reverse();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_end() {
            ITestCase test = new range_end();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_start_end_step() {
            ITestCase test = new range_start_end_step();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void range_start_end_step_descending() {
            ITestCase test = new range_start_end_step_descending();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
