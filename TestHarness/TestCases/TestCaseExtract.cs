using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class extract : ISyncTestCase {
        private const string _Name = "extract";
        private const string _Description = "verifies that extract from seq is corrrect";
        public string TestFile { get { return "TestCaseExtract.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true; 
            int a = 0,b = 0,c = 0,d = 0,e = 0,f = 0;
            
            result = result && (true == F.extract<int>(ref a, F.sequence<int>(1)));
            result = result && (true == F.extract<int>(ref a, ref b, F.sequence<int>(1,2)));
            result = result && (true == F.extract<int>(ref a, ref b, ref c, F.sequence<int>(1,2,3)));
            result = result && (true == F.extract<int>(ref a, ref b, ref c, ref d, F.sequence<int>(1,2,3,4)));
            result = result && (true == F.extract<int>(ref a, ref b, ref c, ref d, ref e, F.sequence<int>(1,2,3,4,5)));
            result = result && (true == F.extract<int>(ref a, ref b, ref c, ref d, ref e, ref e, F.sequence<int>(1,2,3,4,5,6)));
            // missing last one item
            result = result && (false == F.extract<int>(ref a, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, F.sequence<int>(1)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, F.sequence<int>(1,2)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, F.sequence<int>(1,2,3)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, ref e, F.sequence<int>(1,2,3,4)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, ref e, ref f, F.sequence<int>(1,2,3,4,5)));
            // missing last two items
            result = result && (false == F.extract<int>(ref a, ref b, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, F.sequence<int>(1)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, F.sequence<int>(1,2)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, ref e, F.sequence<int>(1,2,3)));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, ref e, ref f, F.sequence<int>(1,2,3,4)));
            // now each extract with an empty sequence
            result = result && (false == F.extract<int>(ref a, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, ref e, F.sequence<int>()));
            result = result && (false == F.extract<int>(ref a, ref b, ref c, ref d, ref e, ref f, F.sequence<int>()));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public extract() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_extract);
            this.feature.Add(TestCoverage.F_extract_1_T);
            this.feature.Add(TestCoverage.F_extract_2_T);
            this.feature.Add(TestCoverage.F_extract_3_T);
            this.feature.Add(TestCoverage.F_extract_4_T);
            this.feature.Add(TestCoverage.F_extract_5_T);
            this.feature.Add(TestCoverage.F_extract_6_T);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_extract);
            this.coverage.Add(TestCoverage.F_extract_1_T);
            this.coverage.Add(TestCoverage.F_extract_2_T);
            this.coverage.Add(TestCoverage.F_extract_3_T);
            this.coverage.Add(TestCoverage.F_extract_4_T);
            this.coverage.Add(TestCoverage.F_extract_5_T);
            this.coverage.Add(TestCoverage.F_extract_6_T);
            this.coverage.Add(TestCoverage.F_sequence_T);
            this.coverage.Add(TestCoverage.F_sequence_1_items_T);
            this.coverage.Add(TestCoverage.F_sequence_2_items_T);
            this.coverage.Add(TestCoverage.F_sequence_3_items_T);
            this.coverage.Add(TestCoverage.F_sequence_4_items_T);
            this.coverage.Add(TestCoverage.F_sequence_5_items_T);
            this.coverage.Add(TestCoverage.F_sequence_6_items_T);
        }
    }
}
