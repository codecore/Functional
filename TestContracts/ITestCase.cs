using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test.Contracts {
    public interface ISyncTestCase {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        string TestFile { get; }
        Func<bool> Run { get; }
        IEnumerable<int> Feature { get; }
        IEnumerable<int> Coverage { get; }
    }
    public interface IAsyncTestCase {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        string TestFile { get; }
        Task<bool> RunAsync();
        IEnumerable<int> Feature { get; }
        IEnumerable<int> Coverage { get; }
    }
}
