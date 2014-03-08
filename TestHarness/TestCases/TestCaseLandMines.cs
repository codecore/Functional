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
    public class inc_landmine : ISyncTestCase {
        private const string _Name = "inc_landmine";
        private const string _Description = "verify that returns and post-increments don't mix";
        public string TestFile { get { return "TestCaseLandMines.cs"; } }
        public Func<bool> Run { get; private set; }
        private static Func<int, int> increment = (x) => x++;
        private static bool _Run() {
            bool result = true;
            result = result && (0 == increment(0));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public inc_landmine() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.LandMine);
            this.feature.Add(TestCoverage.LandMine_inc);

            this.coverage.Add(TestCoverage.LandMine);
            this.coverage.Add(TestCoverage.LandMine_inc);
        }
    }
}
