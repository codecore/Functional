﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestLogger {
        [TestMethod]
        public async Task logger_null_test() {
            IAsyncTestCase test = new logger_null();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task logger_console_test() {
            IAsyncTestCase test = new logger_console();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task logger_filename_test() {
            IAsyncTestCase test = new logger_filename();
            bool result = await test.RunAsync();
            Assert.IsTrue(result);
        }
    }
}
