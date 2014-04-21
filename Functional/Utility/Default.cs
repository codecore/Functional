using System;
using Functional.Contracts.Utility;

namespace Functional.Utility {
    public class Default<T> : IDefault<T> where T : class {
        public Default(T item) {
            this.d = item;
            this.orDefault = (x) =>  (null != x) ? x : this.d;
        }
        private T d = null;
        /// <summary>Function that takes a potentially null object</summary><returns>the original object, or the default object if the original object is null</returns>
        public Func<T,T> orDefault { get; private set; }
    }
}