using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional.Implementation;
using Test.Contracts;
using Tests;
namespace UnitTests.Tests {
    [TestClass]
    public class TestGPS {
        [TestMethod]
        public void gps_nmea_parse_gpgga() {
            ISyncTestCase test = new gps_nmea_parse_gpgga();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gps_nmea_parse_gprmc() {
            ISyncTestCase test = new gps_nmea_parse_gprmc();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gps_nmea_parse_gpgsa() {
            ISyncTestCase test = new gps_nmea_parse_gpgsa();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gps_nmea_parse_gpvtg() {
            ISyncTestCase test = new gps_nmea_parse_gpvtg();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void gps_nmea_parse_gpgsv() {
            ISyncTestCase test = new gps_nmea_parse_gpgsv();
            bool result = test.Run();
            Assert.IsTrue(result);
        }
    }
}
