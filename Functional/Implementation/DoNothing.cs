using System;
using System.Collections.Generic;

using Functional.Contracts;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>A do nothing function that takes zero inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_no_inputs)]
        public static void DoNothing() { }
        /// <summary>A do nothing function that takes one inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_one_input)]
        public static void DoNothing<T>(T t) { }
        /// <summary>A do nothing function that takes two inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_two_inputs)]
        public static void DoNothing<T>(T t1, T t2) { }
        /// <summary>A do nothing function that takes three inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_three_inputs)]
        public static void DoNothing<T>(T t1, T t2, T t3) { }
        /// <summary>A do nothing function that takes four inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_four_inputs)]
        public static void DoNothing<T>(T t1, T t2, T t3, T t4) { }
        /// <summary>A do nothing function that takes a sequence of items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_sequence)]
        public static void DoNothing<T>(IEnumerable<T> items) { }
        /// <summary>A do nothing function that takes two inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_two_types)]
        public static void DoNothing<T,U>(T t, U u) { }
        /// <summary>A do nothing function that takes three inputs</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_donothing_three_types)]
        public static void DoNothing<T,U,V>(T t, U u, V v) { }
    }
}