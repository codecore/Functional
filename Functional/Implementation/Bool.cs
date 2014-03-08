using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>extension of bool</summary><returns>and</returns>
        [Coverage(TestCoverage.bool_And)]
        public static bool And(this bool b1, bool b2) {  return F.bool_and(b1, b2); }
        /// <summary>extension of bool</summary><returns>or</returns>
        [Coverage(TestCoverage.bool_Or)]
        public static bool Or(this bool b1, bool b2) { return F.bool_or(b1, b2); }
        /// <summary>exclusive or</summary><returns>true if b1 != b2</returns>
        [Coverage(TestCoverage.F_bool_xor)]
        public static Func<bool, bool, bool> bool_xor = (left, right) => left != right;
        /// <summary>equivilant</summary><returns>true if b1 == b2</returns>
        [Coverage(TestCoverage.F_bool_eqv)]
        public static Func<bool, bool, bool> bool_eqv = (left, right) => left == right;
        /// <summary>not</summary><returns>boolean negative of the input</returns>
        [Coverage(TestCoverage.F_bool_not)]
        public static Func<bool, bool> bool_not = x => !x;
    }
}