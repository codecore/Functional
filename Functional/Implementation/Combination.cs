using System;
using System.Collections.Generic;

using Functional.Contracts;
using Functional.Utility;
using Functional.Test;
using Functional.Contracts.Utility;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>combines two sequences (size M, and N) in to a sequence of (MxN) pairs</summary><returns>sequence of IPairs</returns>
        [Coverage(TestCoverage.F_combination_combine_TU)]
        public static IEnumerable<IPair<T, U>> combine<T, U>(IEnumerable<T> keys, IEnumerable<U> values) {
            foreach (T key in keys)
                foreach (U value in values)
                    yield return new Pair<T, U>(key, value);
        }
    }
}