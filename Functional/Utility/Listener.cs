using System;

using Functional.Contracts;

namespace Functional.Utility {
    public class Listener<T, U> : IListener<T, U> {
        private Func<T, U> fn;
        private Listener(Func<T, U> fun) 
        {
            this.fn = fun;
            this.Handle = (t)=>this.fn(t);
        }
        public Func<T,U> Handle { get; private set; }
        public static IListener<T, U> Create(Func<T, U> fun) {
            return new Listener<T, U>(fun);
        }
    }
}