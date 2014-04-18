using System;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>returns a function that returns true</summary><returns>a Function that returns a bool</returns>
        [Coverage(TestCoverage.F_always_true)]
        public static Func<Func<bool>> alwaysTrue = () => () => true; 
        /// <summary>returns a function that returns false</summary><returns>a Function that returns a bool</returns>
        [Coverage(TestCoverage.F_always_false)]
        public static Func<Func<bool>> alwaysFalse = () =>  () => false; 
        //[Coverage(TestCoverage.F_always_T)]
        public static Func<T> always<T>(T t) { return () => t; }
    }
}