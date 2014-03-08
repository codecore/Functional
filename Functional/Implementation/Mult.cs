using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(int x1, int x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_int
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(int x1, int x2, int x3) { return x1 * x2 * x3; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(int x1, int x2, int x3, int x4) { return x1 * x2 * x3 * x4; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(int x1, int x2, int x3, int x4, int x5) { return x1 * x2 * x3 * x4 * x5; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(int x1, int x2, int x3, int x4, int x5, int x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(IEnumerable<int> seq) { return F<int>.reduce(seq, mult_int); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(IEnumerable<int> seq, int x) { return F<int>.reduce(seq, mult_int, x); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static int mult_int(int x, IEnumerable<int> seq) { return F<int>.reduce(seq, mult_int, x); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_int)]
        public static IEnumerable<int> mult_int(IEnumerable<int> seq1, IEnumerable<int> seq2) { return F<int>.map<int>(seq1, seq2, mult_int); }

        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(long x1, long x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_long
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(long x1, long x2, long x3) { return x1 * x2 * x3; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(long x1, long x2, long x3, long x4) { return x1 * x2 * x3 * x4; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(long x1, long x2, long x3, long x4, long x5) { return x1 * x2 * x3 * x4 * x5; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(long x1, long x2, long x3, long x4, long x5, long x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(IEnumerable<long> seq) { return F<long>.reduce(seq, mult_long); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(IEnumerable<long> seq, long x) { return F<long>.reduce(seq, mult_long, x); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static long mult_long(long x, IEnumerable<long> seq) { return F<long>.reduce(seq, mult_long, x); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_long)]
        public static IEnumerable<long> mult_long(IEnumerable<long> seq1, IEnumerable<long> seq2) { return F<long>.map<long>(seq1, seq2, mult_long); }

        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(short x1, short x2) { return (short)(x1 * x2); }  // TestCoverage = F, F_mult, F_mult_short
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(short x1, short x2, short x3) { return (short)(x1 * x2 * x3); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(short x1, short x2, short x3, short x4) { return (short)(x1 * x2 * x3 * x4); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(short x1, short x2, short x3, short x4, short x5) { return (short)(x1 * x2 * x3 * x4 * x5); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(short x1, short x2, short x3, short x4, short x5, short x6) { return (short)(x1 * x2 * x3 * x4 * x5 * x6); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(IEnumerable<short> seq) { return F<short>.reduce(seq, mult_short); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(IEnumerable<short> seq, short t) { return F<short>.reduce(seq, mult_short, t); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static short mult_short(short t, IEnumerable<short> seq) { return F<short>.reduce(seq, mult_short, t); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_short)]
        public static IEnumerable<short> mult_short(IEnumerable<short> seq1, IEnumerable<short> seq2) { return F<short>.map<short>(seq1, seq2, mult_short); }

        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(float x1, float x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_float
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(float x1, float x2, float x3) { return x1 * x2 * x3; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(float x1, float x2, float x3, float x4) { return x1 * x2 * x3 * x4; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(float x1, float x2, float x3, float x4, float x5) { return x1 * x2 * x3 * x4 * x5; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(float x1, float x2, float x3, float x4, float x5, float x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(IEnumerable<float> seq) { return F<float>.reduce(seq, mult_float); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(IEnumerable<float> seq, float t) { return F<float>.reduce(seq, mult_float, t); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static float mult_float(float t, IEnumerable<float> seq) { return F<float>.reduce(seq, mult_float, t); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_float)]
        public static IEnumerable<float> mult_float(IEnumerable<float> seq1, IEnumerable<float> seq2) { return F<float>.map<float>(seq1, seq2, mult_float); }

        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(double x1, double x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_double
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(double x1, double x2, double x3) { return x1 * x2 * x3; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(double x1, double x2, double x3, double x4) { return x1 * x2 * x3 * x4; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(double x1, double x2, double x3, double x4, double x5) { return x1 * x2 * x3 * x4 * x5; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(double x1, double x2, double x3, double x4, double x5, double x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(IEnumerable<double> seq) { return F<double>.reduce(seq, mult_double); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(IEnumerable<double> seq, double t) { return F<double>.reduce(seq, mult_double, t); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static double mult_double(double t, IEnumerable<double> seq) { return F<double>.reduce(seq, mult_double, t); }
        /// <summary>given two of more numbers, return the product them</summary><returns>the product</returns>
        [Coverage(TestCoverage.F_mult_double)]
        public static IEnumerable<double> mult_double(IEnumerable<double> seq1, IEnumerable<double> seq2) { return F<double>.map<double>(seq1, seq2, mult_double); }

    }
}