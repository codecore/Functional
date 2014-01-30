using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;
using Functional.Implementation;
using Tests;

using TestContracts;
namespace TestHarness
{
    public interface ITestHarness {
        IEnumerable<ITestCase> Tests { get; }
        IEnumerable<bool> Results();
    }
    public class harness : ITestHarness
    {
        [ImportMany(typeof(ITestCase))]
        private IEnumerable<ITestCase> tests;
        public IEnumerable<ITestCase> Tests { get { return this.tests; } }
        public IEnumerable<bool> Results() {
            return F<ITestCase>.map<bool>(this.Tests, (x) => x.Run());
        }
        private harness() { }
        public static ITestHarness Create() {
            return new harness();
        }
    }

}
