using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F  {
        /// <summary>Given a function that takes a T and function that takes an T and returns a X, return a function that takes an X</summary><returns>Function that takes an X</returns>
        [Coverage(TestCoverage.F_transform_TU)]
        public static Action<T> transform<T,U>(Action<U> action, Func<T,U> fn) { return (n) => action(fn(n)); }
    }
}