using System;
using System.Threading.Tasks;
using Functional.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class integration {
        [TestMethod]
        public void test_intersperse() {
            ISyncTestCase test = new test_intersperse();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
