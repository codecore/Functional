using System;
using System.Collections.Generic;

using Functional.Test;
using Functional.Contracts.Utility;
using Functional.Contracts;
namespace Functional.Implementation {
    public class Option<T> : IOption <T>  {
        public IEnumerator<T> GetEnumerator() {
            return Option<T>.toList(this).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { // this is FU
            return this.GetEnumerator();
        }
        public T Value { get; private set; }
        public bool IsSome { get; private set; }
        public bool IsNone { get { return !this.IsSome; } } // dumb

        
        [Coverage(TestCoverage.Option_bind)]
        public static IOption<U> bind<U>(Func<T,IOption<U>> fn,IOption<T> o) {
            return (o.IsSome) ? fn(o.Value) : Option<U>.None;
        }
        [Coverage(TestCoverage.Option_get)]
        public static T get(IOption<T> o) {
            if (o.IsNone) throw new ArgumentException();
            return o.Value;
        }
        [Coverage(TestCoverage.Option_count)]
        public static int count(IOption<T> o) { return (o.IsSome) ? 1 : 0; }
        [Coverage(TestCoverage.Option_exists)]
        public static bool exists(Func<T,bool> fn, IOption<T> o) {
            return (o.IsSome) ? fn(o.Value) : false;
        }
        [Coverage(TestCoverage.Option_forall)]
        public static bool forall(Func<T, bool> fn, Option<T> o) {
            return (!o.IsSome) ? true : fn(o.Value);
        }
        [Coverage(TestCoverage.Option_iter)]
        public static void iter(Action<T> fn, IOption<T> o) {
            if (o.IsSome) fn(o.Value);
        }
        [Coverage(TestCoverage.Option_toArray)]
        public static T[] toArray(IOption<T> o) {
            T[] x = new T[(o.IsSome)?1:0];
            if (o.IsSome) x[0] = o.Value;
            return x;
        }
        [Coverage(TestCoverage.Option_toList)]
        public static IList<T> toList(IOption<T> o) {
            IList<T> lst = new List<T>();
            if (o.IsSome) lst.Add(o.Value);
            return lst;
        }
        
        private Option(){ this.Value = default(T); this.IsSome = false; }
        private Option(T t) { this.Value = t; this.IsSome = true; }
        private static IOption<T> none = null;

        [Coverage(TestCoverage.Option_Some)]
        public static IOption<T> Some(T t) { return new Option<T>(t); }
        [Coverage(TestCoverage.Option_None)]
        public static IOption<T> None {
            get {
                if (null == none) none = new Option<T>();
                return none;
            }
        }
    }
}
