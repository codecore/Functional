using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>A function given minimum, and maximum, that returns a sequence of random integers</summary><returns>An infinite sequence of random integers between minimum and maximum</returns>
        [Coverage(TestCoverage.F_random_range)]
        public static IEnumerable<int> random(int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            while (true) yield return r.Next(minimum, maximum);
        }
        /// <summary>A function given length, that returns a sequence of random integers</summary><returns>A sequence of random integers</returns>
        [Coverage(TestCoverage.F_random_range_count)]
        public static IEnumerator<int> random(int count) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < count; ++i) yield return r.Next();
        }
        /// <summary>A function given length, minimum, and maximum, that returns a sequence of random integers</summary><returns>A sequence of random integers between minimum and maximum</returns>
        [Coverage(TestCoverage.F_random_range_count)]
        public static IEnumerable<int> random(int count, int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < count; ++i) yield return r.Next(minimum, maximum);
        }
    }
}