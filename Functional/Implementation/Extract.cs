using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>return the first item of a sequence</summary><returns>true is all requested items are returned</returns>
        [Coverage(TestCoverage.F_extract_1_T)]
        public static bool extract<T>(ref T t, IEnumerable<T> seq) {
            int index = 0;
            foreach (T current in seq) {
                index++;
                if (1 == index) { t = current; break; }
            }
            return (1 == index);
        }
        /// <summary>return the first two items of a sequence</summary><returns>true is all requested items are returned</returns>
        [Coverage(TestCoverage.F_extract_2_T)]
        public static bool extract<T>(ref T t1, ref T t2, IEnumerable<T> seq) {
            int index = 0;
            foreach (T current in seq) {
                index++;
                if (1 == index) t1 = current;
                if (2 == index) { t2 = current; break; }
            }
            return (2 == index);
        }
        /// <summary>return the first three items of a sequence</summary><returns>true is all requested items are returned</returns>
        [Coverage(TestCoverage.F_extract_3_T)]
        public static bool extract<T>(ref T t1, ref T t2, ref T t3, IEnumerable<T> seq) {
            int index = 0;
            foreach (T current in seq) {
                index++;
                if (1 == index) t1 = current;
                if (2 == index) t2 = current;
                if (3 == index) { t3 = current; break; }
            }
            return (3 == index);
        }
        /// <summary>return the first four items of a sequence</summary><returns>true is all requested items are returned</returns>
        [Coverage(TestCoverage.F_extract_4_T)]
        public static bool extract<T>(ref T t1, ref T t2, ref T t3, ref T t4, IEnumerable<T> seq) {
            int index = 0;
            foreach (T current in seq) {
                index++;
                if (1 == index) t1 = current;
                if (2 == index) t2 = current;
                if (3 == index) t3 = current;
                if (4 == index) { t4 = current; break; }
            }
            return (4 == index);
        }
        /// <summary>return the first five items of a sequence</summary><returns>true is all requested items are returned</returns>
        [Coverage(TestCoverage.F_extract_5_T)]
        public static bool extract<T>(ref T t1, ref T t2, ref T t3, ref T t4, ref T t5, IEnumerable<T> seq) {
            int index = 0;
            foreach (T current in seq) {
                index++;
                if (1 == index) t1 = current;
                if (2 == index) t2 = current;
                if (3 == index) t3 = current;
                if (4 == index) t4 = current;
                if (5 == index) { t5 = current; break; }
            }
            return (5 == index);
        }
        /// <summary>return the first six items of a sequence</summary><returns>true is all requested items are returned</returns>
        [Coverage(TestCoverage.F_extract_6_T)]
        public static bool extract<T>(ref T t1, ref T t2, ref T t3, ref T t4, ref T t5, ref T t6, IEnumerable<T> seq) {
            int index = 0;
            foreach (T current in seq) {
                index++;
                if (1 == index) t1 = current;
                if (2 == index) t2 = current;
                if (3 == index) t3 = current;
                if (4 == index) t4 = current;
                if (5 == index) t5 = current;
                if (6 == index) { t6 = current; break; }
            }
            return (6 == index);
        }
    }
}
