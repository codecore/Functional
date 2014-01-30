using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestEqu {
        [TestMethod]
        public void equ_bool() {
            ITestCase test = new equ_bool();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_char() {
            ITestCase test = new equ_char();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_int() {
            ITestCase test = new equ_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_long() {
            ITestCase test = new equ_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_short() {
            ITestCase test = new equ_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_string() {
            ITestCase test = new equ_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
