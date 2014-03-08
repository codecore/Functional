using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestEqu {
        [TestMethod]
        public void equ_bool() {
            ISyncTestCase test = new equ_bool();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_char() {
            ISyncTestCase test = new equ_char();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_int() {
            ISyncTestCase test = new equ_int();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_long() {
            ISyncTestCase test = new equ_long();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_short() {
            ISyncTestCase test = new equ_short();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void equ_string() {
            ISyncTestCase test = new equ_string();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
