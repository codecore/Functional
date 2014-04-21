using System;

using Functional.Contracts.Utility;

namespace Functional.Utility {
    public class Pair<U,V> : IPair<U,V> {
        public U Left { get; private set; }
        public V Right { get; private set; }
        private Pair() { }
        public Pair(U left, V right) { this.Left = left; this.Right = right; }
    }
}