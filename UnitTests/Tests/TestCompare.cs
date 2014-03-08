using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void compare_bool() {
            ISyncTestCase test = new compare_bool();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_char() {
            ISyncTestCase test = new close_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_int() {
            ISyncTestCase test = new compare_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_long() {
            ISyncTestCase test = new compare_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_short() {
            ISyncTestCase test = new compare_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_string() {
            ISyncTestCase test = new compare_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_string_insensative() {
            ISyncTestCase test = new compare_string_insensative();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
