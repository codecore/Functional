using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

using Functional.Contracts;

namespace Functional.Utility {
    public class Something<T> : ISomething<T> {
        public T Item { get; set; }
        public override string ToString() { return this.Item.ToString(); }
        private Something(T t){ this.Item = t; }
        public static Func<T,ISomething<T>> Create = (t) => new Something<T>(t);
        public static Func<T,T,int> compare = (t1, t2) => 0; //set this to be useful
        public static Func<ISomething<T>,ISomething<T>,int> Compare = (t1,t2) => compare(t1.Item, t2.Item);
    }
    public class SomethingImmutable<T> : ISomethingImmutable<T> {
        public T Item { get; private set; }
        public override string ToString() { return this.Item.ToString(); }
        private SomethingImmutable(T t) { this.Item = t; }
        public static Func<T,ISomethingImmutable<T>> Create = (t) => new SomethingImmutable<T>(t);
        public static Func<T,T,int> compare = (t1, t2) => 0; //set this to be useful
        public static Func<ISomethingImmutable<T>,ISomethingImmutable<T>,int> Compare = (t1,t2) => compare(t1.Item, t2.Item);
    }
}