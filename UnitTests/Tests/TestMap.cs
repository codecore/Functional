using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestMap {
        [TestMethod]
        public void test_map_one() {
            ISyncTestCase test = new test_map_one();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_map_two() {
            ISyncTestCase test = new test_map_two();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_map_three() {
            ISyncTestCase test = new test_map_three();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
