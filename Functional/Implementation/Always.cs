using System;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>returns a function that returns either true or false</summary><returns>a Function that returns a bool</returns>
        [Coverage(TestCoverage.F_always_function)]
        public static Func<bool,Func<bool>> always = (b) => (b) ? alwaysTrue() : alwaysFalse(); 
        /// <summary>returns a function that returns true</summary><returns>a Function that returns a bool</returns>
        [Coverage(TestCoverage.F_always_true)]
        public static Func<Func<bool>> alwaysTrue = () => () => true; 
        /// <summary>returns a function that returns false</summary><returns>a Function that returns a bool</returns>
        [Coverage(TestCoverage.F_always_false)]
        public static Func<Func<bool>> alwaysFalse = () =>  () => false; 
    }
    public static partial class F<T> {
        /// <summary>returns a function that return the input</summary><returns>a Function</returns>
        [Coverage(TestCoverage.F_always_function)]
        public static Func<T, Func<T>> always = (t) => () => t;
    }
}