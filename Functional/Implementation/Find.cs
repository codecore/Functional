using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>find the first item that meets the condition function throws System.InvalidOperationException if no match is found</summary><returns>T or null</returns>
        [Coverage(TestCoverage.F_T_find)]
        public static Func<IEnumerable<T>, Func<T, bool>, T> find = (lst, predicate) => lst.First(predicate);
    }
}