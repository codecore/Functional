using System;
using System.Threading.Tasks;
using Functional.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class F {
        [TestMethod]
        public void test_chars_string_same() {
            ISyncTestCase test = new test_chars_string_same();
            bool result = test.Run();
            Assert.IsTrue(result);
        }

    }
}
