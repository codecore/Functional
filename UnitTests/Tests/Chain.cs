using System;
using System.Threading.Tasks;
using Functional.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class Chain {
        [TestMethod]
        public void test_chain_one() {
            ISyncTestCase test = new test_chain_one();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
