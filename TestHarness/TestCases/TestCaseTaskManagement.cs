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
    [Export(typeof(IAsyncTestCase))]
    public class task_manager : IAsyncTestCase {
        private const string _Name = "task manager";
        private const string _Description = "task management correctly throttles tasks";
        public string TestFile { get { return "TestCaseTaskManagement.cs"; } }
        public Func<bool> Run { get; private set; }
        public async Task<bool> RunAsync() {
            bool result = true;
            TaskManager tm = new TaskManager();
            bool first = false;
            bool second = false;
            bool third = false;
            bool fourth = false;
            
            
            IEnumerable<Task> tasks = F.sequence<Task>(F.task_action(()=>first = true),F.task_action(()=>second = true),F.task_action(() => third = true),F.task_action(() => fourth = (first&&second&&third)));
            await tm.DoThrottledWork(tasks, 3);
            result = fourth;
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public task_manager() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.Task_Manager);
            this.feature.Add(TestCoverage.Task_Manager_Throttle);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_task);
            this.coverage.Add(TestCoverage.F_task_action);
            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_sequence_T);
            this.coverage.Add(TestCoverage.F_sequence_4_items_T);
            this.coverage.Add(TestCoverage.Task_Manager);
            this.coverage.Add(TestCoverage.Task_Manager_Throttle);
        }
    }
}
