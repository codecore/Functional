using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    [Coverage(TestCoverage.F_all_T)]
    public static partial class F   {
        /// <summary>Given a sequence and a predicate, indicates if every elemnt passes the predicate</summary><returns>true if all the elements pass the predicate function</returns>
        public static bool all<T>(IEnumerable<T> lst, Func<T, bool> predicate) { return lst.All(predicate); }
    }
}