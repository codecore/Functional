using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>A function given two ints</summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        [Coverage(TestCoverage.F_compare_int)]
        public static Func<int,int,int>          compare_int = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        /// <summary>A function given two longs</summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        [Coverage(TestCoverage.F_compare_long)]
        public static Func<long,long,int>       compare_long = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        /// <summary>A function given two shorts</summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        [Coverage(TestCoverage.F_compare_short)]
        public static Func<short,short,int>    compare_short = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        /// <summary>A function given two bools (false &lt; true) </summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        [Coverage(TestCoverage.F_compare_bool)]
        public static Func<bool, bool, int> compare_bool = (l, r) => (l == r) ? 0 : (l == false) ? -1 : 1;
        /// <summary>A function given two chars</summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        [Coverage(TestCoverage.F_compare_char)]
        public static Func<char,char,int>       compare_char = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        /// <summary>A function given two strings</summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        [Coverage(TestCoverage.F_compare_string)]
        public static Func<string, string, int> compare_string = (left, right) => {
            return String.Compare(left, right);
        };
        /// <summary>A function given two strings (ignoring case)</summary><returns>0 if equal, -1 if left &lt; right, 1 if left &gt; right</returns>
        public static Func<string,string,int> compare_string_case_insensative = (left, right) => {
            return String.Compare(left.ToUpper(), right.ToUpper());
        };
    }
}