using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>A function given two ints, false if they are equal</summary><returns>true if they are not equal</returns>
        [Coverage(TestCoverage.F_neq_int)]
        public static Func<int,int,bool>        neq_int = (left, right) => (left != right);
        /// <summary>A function given two longs, false if they are equal</summary><returns>true if they are not equal</returns>
        [Coverage(TestCoverage.F_neq_long)]
        public static Func<long,long,bool>     neq_long = (left, right) => (left != right);
        /// <summary>A function given two shorts, false if they are equal</summary><returns>true if they are not equal</returns>
        [Coverage(TestCoverage.F_neq_short)]
        public static Func<short,short,bool>  neq_short = (left, right) => (left != right);
        /// <summary>A function given two bools, false if they are equal</summary><returns>true if they are not equal</returns>
        [Coverage(TestCoverage.F_neq_bool)]
        public static Func<bool,bool,bool>     neq_bool = bool_xor;
        /// <summary>A function given two chars, false if they are equal</summary><returns>true if they are not equal</returns>
        [Coverage(TestCoverage.F_neq_char)]
        public static Func<char,char,bool>     neq_char = (left, right) => (left != right); // TestCoverage = F, F_neq, F_neq_char
        /// <summary>A function given two strings, true if they are not equal</summary><returns>true if they are not equal</returns>
        [Coverage(TestCoverage.F_neq_string)]
        public static Func<string, string, bool> neq_string = (left, right) => left != right;
    }
}