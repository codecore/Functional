using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestTuple {
        [TestMethod]
        public void tuple_A_B() {
            ISyncTestCase test = new tuple_A_B();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void tuple_A_B_C() {
            ISyncTestCase test = new tuple_A_B_C();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void tuple_A_B_C_D() {
            ISyncTestCase test = new tuple_A_B_C_D();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void tuple_A_B_C_D_E() {
            ISyncTestCase test = new tuple_A_B_C_D_E();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void tuple_A_B_C_D_E_F() {
            ISyncTestCase test = new tuple_A_B_C_D_E_F();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
