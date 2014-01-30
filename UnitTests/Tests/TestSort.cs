using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestSort {
        [TestMethod]
        public void test_sort() {
            ITestCase test = new test_sort();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_sort_order_by() {
            ITestCase test = new test_sort_order_by();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
