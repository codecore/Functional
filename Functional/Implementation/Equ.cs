using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>A function given two ints, true if they are equal</summary><returns>true if they are equal</returns>
        [Coverage(TestCoverage.F_equ_int)]
        public static Func<int,int,bool> equ_int = (left, right) => (left == right);
        /// <summary>A function given two longs, true if they are equal</summary><returns>true if they are equal</returns>
        [Coverage(TestCoverage.F_equ_long)]
        public static Func<long,long,bool> equ_long = (left, right) => (left == right);
        /// <summary>A function given two shorts, true if they are equal</summary><returns>true if they are equal</returns>
        [Coverage(TestCoverage.F_equ_short)]
        public static Func<short,short,bool> equ_short = (left, right) => (left == right);
        /// <summary>A function given two bools, true if they are equal</summary><returns>true if they are equal</returns>
        [Coverage(TestCoverage.F_equ_bool)]
        public static Func<bool,bool,bool> equ_bool = (left, right) => (left == right);
        /// <summary>A function given two chars, true if they are equal</summary><returns>true if they are equal</returns>
        [Coverage(TestCoverage.F_equ_char)]
        public static Func<char,char,bool> equ_char = (left, right) => (left == right);
        /// <summary>A function given two strings, true if they are equal</summary><returns>true if they are equal</returns>
        [Coverage(TestCoverage.F_equ_string)]
        public static Func<string, string, bool> equ_string = (left, right) => {
            return left == right;
        };
    }
}