using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Given a predicate function fn(x) return !fn(x)</summary><returns>The compliment if the predicate function</returns>
        [Coverage(TestCoverage.F_T_compliment_not_predicate)]
        public static Func<T, bool> compliment(Func<T, bool> fn) {
            return (t) => !fn(t);
        }
        /// <summary>Swap the order of the parameters. compliment of f(a,b) is f(b,a)</summary><returns>T, the result of the call</returns>
        [Coverage(TestCoverage.F_T_compliment_swap_params)]
        public static Func<T, T, T> compliment(Func<T, T, T> fn) {
            return (x, y) => fn(y, x); 
        }
    }
}