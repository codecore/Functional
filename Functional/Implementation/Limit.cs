using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Test;

using Functional.Contracts;
namespace Functional.Implementation {

    public static partial class F {
        /// <summary>returns a limitted number of elements from a sequence</summary><returns>a sequence</returns>
        [Coverage(TestCoverage.F_limit_T)]
        public static IEnumerable<T> limit<T>(IEnumerable<T> lst, int count) { return lst.Take(count); }
    }
}
