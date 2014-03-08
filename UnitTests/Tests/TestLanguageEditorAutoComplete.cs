using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageEditorAutoComplete {
        [TestMethod]
        public void test_editor_codelinetest_auto_complete_add_item() {
            ISyncTestCase test = new test_auto_complete_add_item();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
