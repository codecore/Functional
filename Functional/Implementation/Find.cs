using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>find the first item that meets the condition function throws System.InvalidOperationException if no match is found</summary><returns>T or null</returns>
        [Coverage(TestCoverage.F_find_T)]
        public static T find<T>(IEnumerable<T> lst, Func<T, bool> predicate) { return lst.First(predicate); }
    }
}