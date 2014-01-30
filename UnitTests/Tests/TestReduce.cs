using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestReduce {
        [TestMethod]
        public void test_reduce_with_init() {
            ITestCase test = new test_reduce_with_init();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_reduce_one() {
            ITestCase test = new test_reduce_one();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
