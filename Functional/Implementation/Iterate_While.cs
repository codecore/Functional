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
        /// <summary>runs an accumulatr function as long as the check function is true</summary><returns>a sequence of T</returns>
        [Coverage(TestCoverage.F_iterate_while_T)]
        public static IEnumerable<T> iterate_while<T>(Func<T,T> fn, Func<T, bool> predicate, T init) {
            T result = init;
            while (predicate(result)) {
                yield return result;
                result = fn(result);
            }
        }
    }
}
