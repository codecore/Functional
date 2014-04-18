using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>add a pair of ints</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(int x1, int x2){ return x1 + x2;}
        /// <summary>add a set of ints</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(int x1, int x2, int x3) { return x1 + x2 + x3; }
        /// <summary>add a set of ints</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(int x1, int x2, int x3, int x4) { return x1 + x2 + x3 + x4; }
        /// <summary>add a set of ints</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(int x1, int x2, int x3, int x4, int x5) { return x1 + x2 + x3 + x4 + x5; }
        /// <summary>add a set of ints</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(int x1, int x2, int x3, int x4, int x5, int x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        /// <summary>add a sequence of ints</summary><returns>sum of the sequence of ints</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(IEnumerable<int> seq) { return F.reduce<int>(seq, F.add_int); }
        /// <summary>add an int with a sequence of ints</summary><returns>sum of all the ints</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(int t, IEnumerable<int> seq) { return F.reduce<int>(seq, F.add_int, t); }
        /// <summary>add a sequence of ints with an int</summary><returns>sum of all the ints</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static int add_int(IEnumerable<int> seq, int t) { return F.reduce<int>(seq, F.add_int, t); }
        /// <summary>add a sequence of ints with another sequence of ints</summary><returns>a sequence of sums</returns>
        [Coverage(TestCoverage.F_add_int)]
        public static IEnumerable<int> add_int(IEnumerable<int> seq1, IEnumerable<int> seq2) { return F.map<int,int>(seq1, seq2, add_int); }


        /// <summary>add a pair of longs</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(long x1, long x2) { return x1 + x2; }
        /// <summary>add a set of longs</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(long x1, long x2, long x3) { return x1 + x3 + x3; }
        /// <summary>add a set of longs</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(long x1, long x2, long x3, long x4) { return x1 + x2 + x3 + x4; }
        /// <summary>add a set of longs</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(long x1, long x2, long x3, long x4, long x5) { return x1 + x2 + x3 + x4 + x5; }
        /// <summary>add a set of longs</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(long x1, long x2, long x3, long x4, long x5, long x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        /// <summary>add a sequence of longs</summary><returns>sum of the sequence of longs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(IEnumerable<long> seq) { return F.reduce<long>(seq, add_long); }
        /// <summary>add a long with a sequence of longs</summary><returns>sum of all the longs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(long t, IEnumerable<long> seq) { return F.reduce<long>(seq, add_long, t); }
        /// <summary>add a sequence of longs with a long</summary><returns>sum of all the longs</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static long add_long(IEnumerable<long> seq, long t) { return F.reduce<long>(seq, add_long, t); }
        /// <summary>add a sequence of longs with a sequence of longs</summary><returns>a sequence of sums</returns>
        [Coverage(TestCoverage.F_add_long)]
        public static IEnumerable<long> add_long(IEnumerable<long> seq1, IEnumerable<long> seq2) { return F.map<long,long>(seq1, seq2, add_long); }

        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(short x1, short x2) { return (short)(x1 + x2); }
        /// <summary>add a set of shorts</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(short x1, short x2, short x3) { return (short)(x1 + x2 + x3); }
        /// <summary>add a set of shorts</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(short x1, short x2, short x3, short x4) { return (short)(x1 + x2 + x3 + x4); }
        /// <summary>add a set of shorts</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(short x1, short x2, short x3, short x4, short x5) { return (short)(x1 + x2 + x3 + x4 + x5); }
        /// <summary>add a set of shorts</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(short x11, short x2, short x3, short x4, short x5, short x6) { return (short)(x11 + x2 + x3 + x4 + x5 + x6); }
        /// <summary>add a sequence of shorts</summary><returns>sum of the sequence of shorts</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(IEnumerable<short> seq) { return F.reduce<short>(seq, add_short); }
        /// <summary>add a sequence of shorts with a short</summary><returns>sum of all the shorts</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(IEnumerable<short> seq, short t) { return F.reduce<short>(seq, add_short, t); }
        /// <summary>add a short with a sequence of shorts</summary><returns>sum of all the shorts</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static short add_short(short t, IEnumerable<short> seq) { return F.reduce<short>(seq, add_short, t); }
        /// <summary>add a sequence of shorts with a sequence shorts</summary><returns>a sequence of sums</returns>
        [Coverage(TestCoverage.F_add_short)]
        public static IEnumerable<short> add_short(IEnumerable<short> seq1, IEnumerable<short> seq2) { return F.map<short,short>(seq1, seq2, add_short); }


        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(float x1, float x2) { return x1 + x2; } // TestCoverage = F, F_add, F_add_float
        /// <summary>add a set of floats</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(float x1, float x2, float x3) { return x1 + x2 + x3; }
        /// <summary>add a set of floats</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(float x1, float x2, float x3, float x4) { return x1 + x2 + x3 + x4; }
        /// <summary>add a set of floats</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(float x1, float x2, float x3, float x4, float x5) { return x1 + x2 + x3 + x4 + x5; }
        /// <summary>add a set of floats</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(float x1, float x2, float x3, float x4, float x5, float x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        /// <summary>add a sequence of floats</summary><returns>sum of the sequence of floats</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(IEnumerable<float> seq) { return F.reduce<float>(seq, add_float); }
        /// <summary>add a sequence of floats with a float</summary><returns>sum of all the floats</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(IEnumerable<float> seq, float t) { return F.reduce<float>(seq, add_float, t); }
        /// <summary>add a float with a sequence of floats</summary><returns>sum of all the floats</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static float add_float(float t, IEnumerable<float> seq) { return F.reduce<float>(seq, add_float, t); }
        /// <summary>add a sequence of floats with a sequence of floats</summary><returns>sequence of sums</returns>
        [Coverage(TestCoverage.F_add_float)]
        public static IEnumerable<float> add_float(IEnumerable<float> seq1, IEnumerable<float> seq2) { return F.map<float,float>(seq1, seq2, add_float); }

        /// <summary>add a pair of doubles</summary><returns>sum of all the inputs</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(double x1, double x2) { return x1 + x2; } // TestCoverage = F, F_add, F_add_double
        /// <summary>add a set of doubles</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(double x1, double x2, double x3) { return x1 + x2 + x3; }
        /// <summary>add a set of doubles</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(double x1, double x2, double x3, double x4) { return x1 + x2 + x3 + x4; }
        /// <summary>add a set of doubles</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(double x1, double x2, double x3, double x4, double x5) { return x1 + x2 + x3 + x4 + x5; }
        /// <summary>add a set of doubles</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(double x1, double x2, double x3, double x4, double x5, double x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        /// <summary>add a sequence of doubles</summary><returns>sum of the sequence of doubles</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(IEnumerable<double> seq) { return F.reduce<double>(seq, add_double); }
        /// <summary>add a sequence of doubles with a double</summary><returns>sum of all the doubles</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(IEnumerable<double> seq, double t) { return F.reduce<double>(seq, add_double, t); }
        /// <summary>add a double with a sequence of doubles</summary><returns>sum of all the doubles</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static double add_double(double t, IEnumerable<double> seq) { return F.reduce<double>(seq, add_double, t); }
        /// <summary>add a sequence of doubles with a sequence of doubles</summary><returns>sequence of sums</returns>
        [Coverage(TestCoverage.F_add_double)]
        public static IEnumerable<double> add_double(IEnumerable<double> seq1, IEnumerable<double> seq2) { return F.map<double,double>(seq1, seq2, add_double); }

        /// <summary>A function given two strings, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(string s1, string s2) { return s1 + s2; }
        /// <summary>A function given three strings, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(string s1, string s2, string s3) { return s1 + s2 + s3; }
        /// <summary>A function given four strings, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(string s1, string s2, string s3, string s4) { return s1 + s2 + s3 + s4; }
        /// <summary>A function given five strings, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(string s1, string s2, string s3, string s4, string s5) { return s1 + s2 + s3 + s4 + s5; }
        /// <summary>A function given six strings, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(string s1, string s2, string s3, string s4, string s5, string s6) { return s1 + s2 + s3 + s4 + s5 + s6; }
        /// <summary>A function given a sequence of strings, returns the combined string</summary><returns>A combined string</returns>
        //[Coverage(TestCoverage.F_add_string)]
        public static string add_string(IEnumerable<string> seq) { return F.reduce<string>(seq, add_string); }
        /// <summary>A function given a sequence of strings and a string, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(IEnumerable<string> seq, string s) { return F.reduce<string>(seq, add_string, s); }
        /// <summary>A function given a strings and a sequence of strings, returns the combined string</summary><returns>A combined string</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static string add_string(string s, IEnumerable<string> seq) { return F.reduce<string>(seq, add_string, s); }
        /// <summary>A function given two sequences of strings, returns a seqence of combined strings</summary><returns>A sequence of combined strings</returns>
        [Coverage(TestCoverage.F_add_string)]
        public static IEnumerable<string> add_string(IEnumerable<string> seq1, IEnumerable<string> seq2) { return F.map<string,string>(seq1, seq2, add_string); }
    }
}