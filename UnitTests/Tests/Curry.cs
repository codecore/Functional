using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class Curry {
        [TestMethod]
        public void test_curry_one() {
            ITestCase test = new test_curry_one();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_curry_two() {
            ITestCase test = new test_curry_two();
            bool result = test.Run();
            Assert.IsTrue(result);
        }

    }
}
