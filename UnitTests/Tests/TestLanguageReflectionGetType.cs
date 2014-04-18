using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageReflectionGetType {
        [TestMethod]
        public void reflection_gettype() {
            ISyncTestCase test = new reflection_gettype();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
