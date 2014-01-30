using System;
using System.Threading.Tasks;
using Functional.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class integration {
        [TestMethod]
        public void test_intersperse() {
            ITestCase test = new test_intersperse();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
