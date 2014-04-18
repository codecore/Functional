using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Given a sequence and a predicate, indicates if any elemnt passes the predicate</summary><returns>true if any of the elements pass the predicate function</returns>
        [Coverage(TestCoverage.F_any_T)]
        public static bool any<T>(IEnumerable<T> lst, Func<T, bool> predicate) { return lst.Any(predicate); }
    }
}