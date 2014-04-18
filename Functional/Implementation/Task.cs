using System;
using System.Threading.Tasks;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        // <summary>creates a new task basd on an action</summary><returns>a started task</returns>
        [Coverage(TestCoverage.F_task_action)]
        public static Func<Action, Task> task_action = (a) => {
            Task task = new Task(a);
            task.Start();
            return task;
        };

        [Coverage(TestCoverage.F_task_task_T)]
        public static Task<T> task<T>(T t) {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(t);
            return tcs.Task;
        }
    }
}