using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageReflectionLoadAssembly {
        [TestMethod]
        public void reflection_loadassembly() {
            ISyncTestCase test = new reflection_loadassembly();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
