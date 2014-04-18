using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Utility;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class test_crc16 : ISyncTestCase {
        private const string _Name = "test_crc16";
        private const string _Description = "verify that crc16 and fcrc16 compute the same CRC";
        public string TestFile { get { return "TestCaseCrc16.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            FCrc16 fcrc = new FCrc16();
            Crc16 crc = new Crc16();
            result = F.same<ushort>(fcrc.Table.AsEnumerable(), crc.Table.AsEnumerable(), (u1, u2) => u1 == u2);
            byte[] test = new byte[] { 0x45, 0x19, 0xA7, 0x00, 0xFE, 0xFF, 0x04, 0x4A };
            ushort fChecksum = fcrc.ComputeChecksum(test);
            ushort cChecksum = crc.ComputeChecksum(test);
            result = result && (fChecksum == cChecksum);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_crc16() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Utility);
            this.feature.Add(TestCoverage.Utility_crc16);
            this.feature.Add(TestCoverage.Utility_crc16_func);

            this.coverage.Add(TestCoverage.F_same_seq_T);
            this.coverage.Add(TestCoverage.Utility);
            this.coverage.Add(TestCoverage.Utility_crc16);
            this.coverage.Add(TestCoverage.Utility_crc16_func);
        }
    }
}