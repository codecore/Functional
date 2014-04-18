using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>get the sequence following the first element of a sequence</summary><returns>an IEnermerable following the first element</returns>
        [Coverage(TestCoverage.F_rest_T)] // TestCoverage = F_T, F_T_rest
        public static IEnumerable<T> rest<T>(IEnumerable<T> lst) { return lst.Skip(1); }
    }
}