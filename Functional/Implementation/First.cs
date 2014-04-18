using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>get the first element of a sequence</summary><returns>The first element of an IEnumerable</returns>
        [Coverage(TestCoverage.F_first_T)]
        public static T first<T>(IEnumerable<T> lst) { return lst.First(); }
    }
}