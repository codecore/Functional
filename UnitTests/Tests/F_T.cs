using System;
using System.Threading.Tasks;
using Functional.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestContracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class F_T {
        [TestMethod]
        public void test_items() {
            ISyncTestCase test = new test_items();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_transform() {
            ISyncTestCase test = new test_transform();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_same() {
            ISyncTestCase test = new test_same();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_any() {
            ISyncTestCase test = new test_any();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_all() {
            ISyncTestCase test = new test_all();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_filter() {
            ISyncTestCase test = new test_filter();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_first() {
            ISyncTestCase test = new test_first();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_rest() {
            ISyncTestCase test = new test_rest();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_find() {
            ISyncTestCase test = new test_find();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_iterate_while() {
            ISyncTestCase test = new test_iterate_while();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_always() {
            ISyncTestCase test = new test_always();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_flatten_one() {
            ISyncTestCase test = new test_flatten_one();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
