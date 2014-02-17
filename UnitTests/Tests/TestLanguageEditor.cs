using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageEditor {
        [TestMethod]
        public void test_editor_codeline() {
            ISyncTestCase test = new test_editor_codeline();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
