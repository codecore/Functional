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
        // <summary>takes a bool and returns a Task&lt;bool&gt;</summary><returns>Task&lt;bool&gt;</returns>
        [Coverage(TestCoverage.F_task_bool_async)]
        public static Func<bool, Task<bool>> boolAsync = (b) => F<bool>.task(b);
        // <summary>takes a 'true' and returns a Task&lt;bool&gt;</summary><returns>Task&lt;bool&gt; where the result is true</returns>
        [Coverage(TestCoverage.F_task_true_async)]
        public static Func<Task<bool>> trueAsync = () => F<bool>.task(true);
        // <summary>takes a 'false' and returns a Task&lt;bool&gt;</summary><returns>Task&lt;bool&gt; where the result is false</returns>
        [Coverage(TestCoverage.F_task_false_async)]
        public static Func<Task<bool>> falseAsync = () => F<bool>.task(false);
        // <summary>takes a boolean and returns a Task of a function that returns that boolean value</summary><returns>Task&ltFunc&ltbool&gt;&gt;</returns>
        [Coverage(TestCoverage.F_task_always_async)]
        public static Func<bool, Task<Func<bool>>> alwaysAsync = (b) => F<Func<bool>>.task(F.always(b));
        // <summary>returns a Task of a function that return true</summary><returns>task</returns>
        [Coverage(TestCoverage.F_task_always_true_async)]
        public static Func<Task<Func<bool>>> alwaysTrueAsync = () => F<Func<bool>>.task(F.alwaysTrue.Invoke());
        // <summary>returns a Task of a function that return false</summary><returns>task</returns>
        [Coverage(TestCoverage.F_task_always_false_async)]
        public static Func<Task<Func<bool>>> alwaysFalseAsync = () => F<Func<bool>>.task(F.alwaysFalse.Invoke());
    }
    public static partial class F<T> {
        // <summary>takes a T and returns a Task<T></summary><returns>Task<T></returns>
        [Coverage(TestCoverage.F_T_task_task)]
        public static Func<T, Task<T>> task = (t) => {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(t);
            return tcs.Task;
        };
    }
}