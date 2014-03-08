using System;
using System.Collections.Generic;

using Functional.Implementation;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>takes an object, and returns an infinite sequence of the same item</summary><returns>A sequence the same item</returns>
        [Coverage(TestCoverage.F_T_forever_item_one)]
        // TestCoverage = F_T, F_T_forever, F_T_forever_item
        public static IEnumerable<T> forever(T t) {
            while (true) yield return t; 
        }
        /// <summary>takes an a pair of objects, and returns an infinite sequence these items</summary><returns>A sequence of alternating items</returns>
        [Coverage(TestCoverage.F_T_forever_item_two)]
        public static IEnumerable<T> forever(T t1, T t2) {
            while (true) {
                yield return t1;
                yield return t2;
            }
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_T_forever_item_three)]
        public static IEnumerable<T> forever(T t1, T t2, T t3) {
            while (true) foreach(T t in F<T>.sequence(t1,t2,t3)) yield return t;
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_T_forever_item_four)]
        public static IEnumerable<T> forever(T t1, T t2, T t3, T t4) {
            while (true) foreach(T t in F<T>.sequence(t1,t2,t3,t4)) yield return t;
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_T_forever_item_five)]
        public static IEnumerable<T> forever(T t1, T t2, T t3, T t4, T t5) {
            while (true) foreach (T t in F<T>.sequence(t1, t2, t3, t4, t5)) yield return t;
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_T_forever_item_six)]
        public static IEnumerable<T> forever(T t1, T t2, T t3, T t4, T t5, T t6) {
            while (true) foreach (T t in F<T>.sequence(t1, t2, t3, t4, t5, t6)) yield return t;
        }
        /// <summary>takes an a sequence of objects</summary><returns>A repeating sequence of items</returns>
        [Coverage(TestCoverage.F_T_forever_sequence)]
        public static IEnumerable<T> forever(IEnumerable<T> e) {
            while (true) foreach (T t in e) yield return t;
        }
        /// <summary>takes a function and an initial value</summary><returns>A infinate sequence of iterated items</returns>
        [Coverage(TestCoverage.F_T_forever_function_simple)]
        public static IEnumerable<T> forever(Func<T, T> fn, T t) {
            T result = t;
            while (true) {
                yield return result;
                result = fn(result);
            }
        }
    }
}