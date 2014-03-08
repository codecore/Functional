using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Given a function that takes a T and function that takes an T and returns a X, return a function that takes an X</summary><returns>Function that takes an X</returns>
        [Coverage(TestCoverage.F_T_transform)]
        public static Action<T> transform<X>(Action<X> action, Func<T, X> fn) { return (n) => action(fn(n)); }
    }
}