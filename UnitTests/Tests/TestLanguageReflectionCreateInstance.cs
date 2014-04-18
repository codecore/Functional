using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageReflectionCreateInstance {
        [TestMethod]
        public void reflection_create() {
            ISyncTestCase test = new reflection_create();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
