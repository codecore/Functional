﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestSort {
        [TestMethod]
        public void test_sort() {
            ISyncTestCase test = new test_sort();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_sort_order_by() {
            ISyncTestCase test = new test_sort_order_by();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void test_merge_sort() {
            ISyncTestCase test = new test_sort_merge();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
