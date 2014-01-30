using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void compare_bool() {
            ITestCase test = new compare_bool();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_char() {
            ITestCase test = new close_double();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_int() {
            ITestCase test = new compare_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_long() {
            ITestCase test = new compare_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_short() {
            ITestCase test = new compare_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_string() {
            ITestCase test = new compare_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void compare_string_insensative() {
            ITestCase test = new compare_string_insensative();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
