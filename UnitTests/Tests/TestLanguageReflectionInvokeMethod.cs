using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLanguageReflectionInvokeMethod {
        [TestMethod]
        public void reflection_invoke_instance_non_void_method() {
            ISyncTestCase test = new reflection_invoke_instance_non_void_method();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void reflection_invoke_instance_void_method() {
            ISyncTestCase test = new reflection_invoke_instance_void_method();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void reflection_invoke_static_non_void_method() {
            ISyncTestCase test = new reflection_invoke_static_non_void_method();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void reflection_invoke_static_void_method() {
            ISyncTestCase test = new reflection_invoke_static_void_method();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
