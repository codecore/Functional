using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>Given a predicate function fn(x) return !fn(x)</summary><returns>The compliment if the predicate function</returns>
        [Coverage(TestCoverage.F_compliment_not_predicate_T)]
        public static Func<T, bool> compliment<T>(Func<T, bool> fn) {
            return (t) => !fn(t);
        }
        /// <summary>Swap the order of the parameters. compliment of f(a,b) is f(b,a)</summary><returns>T, the result of the call</returns>
        [Coverage(TestCoverage.F_compliment_swap_params_T)]
        public static Func<T, T, T> compliment<T>(Func<T, T, T> fn) {
            return (x, y) => fn(y, x); 
        }
        /// <summary>Swap the order of the parameter types. compliment of f(T a, U b) is f(U b,T a)</summary><returns>T, the result of the call</returns>
        [Coverage(TestCoverage.F_compliment_swap_type_TUV)]
        public static Func<U, T, V> compliment<T, U, V>(Func<T, U, V> fn) {
            return (x, y) => fn(y, x);
        }
    }
}