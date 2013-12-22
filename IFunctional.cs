using System;
using System.IO;
using System.Collections.Generic;

namespace Functional.Contracts {
    public delegate IEnumerable<string> GetStrings(StreamReader sr);
    public interface IListener<T, U> { U Handle(T m); }
    public interface ISomething<T> {
        T Item { get; set; }
    }
    public interface ISomethingImmutable<T> {
        T Item { get; }
    }
    public interface IDefault<T> {
        T orDefault(T t);
    }
    public interface ICurry1<T, U> {
        Func<T, U> Create();
    }
    public interface ICurry2<T, U> {
        Func<U, U> Create(T t);
    }
    
}
