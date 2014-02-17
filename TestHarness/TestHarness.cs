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
        IEnumerable<ISyncTestCase> SyncTests { get; }
        IEnumerable<IAsyncTestCase> AsyncTests { get; }
    }
    public class harness : ITestHarness
    {
        [ImportMany(typeof(ISyncTestCase))]
        private IEnumerable<ISyncTestCase> syncTests;
        public IEnumerable<ISyncTestCase> SyncTests { get { return this.syncTests; } }
        [ImportMany(typeof(IAsyncTestCase))]
        private IEnumerable<IAsyncTestCase> asyncTests;
        public IEnumerable<IAsyncTestCase> AsyncTests { get { return this.asyncTests; } }
        private harness() { }
        public static ITestHarness Create() {
            return new harness();
        }
    }

}
