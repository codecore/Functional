using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLandmineIncrement {
        [TestMethod]
        public void inc_landmine() {
            ISyncTestCase test = new inc_landmine();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
