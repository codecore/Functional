using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static int min_int(int x1, int x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_int
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static int min_int(int x1, int x2, int x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static int min_int(int x1, int x2, int x3, int x4) {
            int t1 = (x1 < x2) ? x1 : x2; int t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static int min_int(int x1, int x2, int x3, int x4, int x5) {
            int t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            int t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static int min_int(int x1, int x2, int x3, int x4, int x5, int x6) {
            int t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            int t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static int min_int(IEnumerable<int> seq) {
            int result = F.first<int>(seq);
            foreach (int t in F.rest<int>(seq)) result = min_int(result, t);
            return result;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_int)]
        public static IEnumerable<int> min_int(IEnumerable<int> seq1, IEnumerable<int> seq2) {
            IEnumerator<int> e1 = seq1.GetEnumerator();
            IEnumerator<int> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_int(e1.Current,e2.Current);
            }
        }

        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static long min_long(long x1, long x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_long
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static long min_long(long x1, long x2, long x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static long min_long(long x1, long x2, long x3, long x4) {
            long t1 = (x1 < x2) ? x1 : x2; long t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static long min_long(long x1, long x2, long x3, long x4, long x5) {
            long t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            long t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static long min_long(long x1, long x2, long x3, long x4, long x5, long x6) {
            long t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            long t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static long min_long(IEnumerable<long> seq) {
            long result = F.first<long>(seq);
            foreach (long t in F.rest<long>(seq)) result = min_long(result, t);
            return result;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_long)]
        public static IEnumerable<long> min_long(IEnumerable<long> seq1, IEnumerable<long> seq2) {
            IEnumerator<long> e1 = seq1.GetEnumerator();
            IEnumerator<long> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_long(e1.Current,e2.Current);
            }
        }

        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static short min_short(short x1, short x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_short
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static short min_short(short x1, short x2, short x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static short min_short(short x1, short x2, short x3, short x4) {
            short t1 = (x1 < x2) ? x1 : x2; short t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static int min_short(short x1, short x2, short x3, short x4, short x5) {
            short t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            short t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static short min_short(short x1, short x2, short x3, short x4, short x5, short x6) {
            short t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            short t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static short min_short(IEnumerable<short> seq) {
            short result = F.first<short>(seq);
            foreach (short t in F.rest<short>(seq)) result = min_short(result, t);
            return result;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_short)]
        public static IEnumerable<short> min_short(IEnumerable<short> seq1, IEnumerable<short> seq2) {
            IEnumerator<short> e1 = seq1.GetEnumerator();
            IEnumerator<short> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_short(e1.Current,e2.Current);
            }
        }

        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static float min_float(float x1, float x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_float
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static float min_float(float x1, float x2, float x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        /// <summary>given two of more numbers, return the minimum one</summary>
        /// <returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static float min_float(float x1, float x2, float x3, float x4) {
            float t1 = (x1 < x2) ? x1 : x2; float t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static float min_float(float x1, float x2, float x3, float x4, float x5) {
            float t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            float t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static float min_float(float x1, float x2, float x3, float x4, float x5, float x6) {
            float t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            float t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static float min_float(IEnumerable<float> seq) {
            float result = F.first<float>(seq);
            foreach (float t in F.rest<float>(seq)) result = min_float(result, t);
            return result;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_float)]
        public static IEnumerable<float> min_float(IEnumerable<float> seq1, IEnumerable<float> seq2) {
            IEnumerator<float> e1 = seq1.GetEnumerator();
            IEnumerator<float> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_float(e1.Current,e2.Current);
            }
        }

        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static double min_double(double x1, double x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_double
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static double min_doule(double x1, double x2, double x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static double min_double(double x1, double x2, double x3, double x4) {
            double t1 = (x1 < x2) ? x1 : x2; double t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static double min_double(double x1, double x2, double x3, double x4, double x5) {
            double t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            double t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static double min_double(double x1, double x2, double x3, double x4, double x5, double x6) {
            double t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            double t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static double min_double(IEnumerable<double> seq) {
            double result = F.first<double>(seq);
            foreach (double t in F.rest<double>(seq)) result = min_double(result, t);
            return result;
        }
        /// <summary>given two of more numbers, return the minimum one</summary><returns>the minimum number</returns>
        [Coverage(TestCoverage.F_min_double)]
        public static IEnumerable<double> min_double(IEnumerable<double> seq1, IEnumerable<double> seq2) {
            IEnumerator<double> e1 = seq1.GetEnumerator();
            IEnumerator<double> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_double(e1.Current,e2.Current);
            }
        }
    }
}