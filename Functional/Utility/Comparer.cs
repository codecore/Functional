using System;
using System.Collections.Generic;

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
    public class EqualityComparer<T> : IEqualityComparer<T> {
        private Func<T, T, bool> compare = null;
        public bool Equals(T t1, T t2) {
            return this.compare(t1, t2);
        }
        public int GetHashCode(T t) { return t.GetHashCode(); } // where the value here?
        private EqualityComparer() { }
        private EqualityComparer(Func<T, T, bool> fn) { this.compare = fn; }
        public static IEqualityComparer<T> Create(Func<T, T, bool> fn) { return new EqualityComparer<T>(fn); }
    }
}