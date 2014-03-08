using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestEach {
        [TestMethod]
        public void test_each() {
            ISyncTestCase test = new test_each();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
