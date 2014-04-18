using System;
using System.Collections.Generic;

using Functional.Implementation;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>takes an object, and returns an infinite sequence of the same item</summary><returns>A sequence the same item</returns>
        [Coverage(TestCoverage.F_forever_item_1_T)]
        public static IEnumerable<T> forever<T>(T t) {
            while (true) yield return t; 
        }
        /// <summary>takes an a pair of objects, and returns an infinite sequence these items</summary><returns>A sequence of alternating items</returns>
        [Coverage(TestCoverage.F_forever_item_2_T)]
        public static IEnumerable<T> forever<T>(T t1, T t2) {
            while (true) {
                yield return t1;
                yield return t2;
            }
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_forever_item_3_T)]
        public static IEnumerable<T> forever<T>(T t1, T t2, T t3) {
            while (true) foreach(T t in F.sequence<T>(t1,t2,t3)) yield return t;
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_forever_item_4_T)]
        public static IEnumerable<T> forever<T>(T t1, T t2, T t3, T t4) {
            while (true) foreach(T t in F.sequence<T>(t1,t2,t3,t4)) yield return t;
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_forever_item_5_T)]
        public static IEnumerable<T> forever<T>(T t1, T t2, T t3, T t4, T t5) {
            while (true) foreach (T t in F.sequence<T>(t1, t2, t3, t4, t5)) yield return t;
        }
        /// <summary>takes an a set of objects, and returns an infinite sequence these items</summary><returns>A repeating sequence of alternating items</returns>
        [Coverage(TestCoverage.F_forever_item_6_T)]
        public static IEnumerable<T> forever<T>(T t1, T t2, T t3, T t4, T t5, T t6) {
            while (true) foreach (T t in F.sequence<T>(t1, t2, t3, t4, t5, t6)) yield return t;
        }
        /// <summary>takes an a sequence of objects</summary><returns>A repeating sequence of items</returns>
        [Coverage(TestCoverage.F_forever_sequence_T)]
        public static IEnumerable<T> forever<T>(IEnumerable<T> e) {
            while (true) foreach (T t in e) yield return t;
        }
        /// <summary>takes a function and an initial value</summary><returns>A infinate sequence of iterated items</returns>
        [Coverage(TestCoverage.F_forever_function_simple_T)]
        public static IEnumerable<T> forever<T>(Func<T,T> fn, T t) {
            T result = t;
            while (true) {
                yield return result;
                result = fn(result);
            }
        }
    }
}