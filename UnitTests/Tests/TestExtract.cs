using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestExtract {
        [TestMethod]
        public void extract() {
            ISyncTestCase test = new extract();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
