using System;
using Functional.Contracts;

namespace Functional.Utility {
    /// <summary>A compare object requires by a sort function in the .NET framework</summary><returns>System.Collections.Generic.Comparer&lt;T&gt;</returns>
    public class Comparer<T> : System.Collections.Generic.Comparer<T> {
        private Func<T, T, int> compare;
        public Comparer(Func<T, T, int> fn) {
            this.compare = fn; 
        }
        public override int Compare(T x, T y) {
            return this.compare.Invoke(x, y);
        }
    }
}