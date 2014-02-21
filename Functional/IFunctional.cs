using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Functional.Contracts {
    public interface IPair<U, V> {
        U Left { get; }
        V Right { get; }
    }
    public delegate IEnumerable<string> GetStrings(StreamReader sr);
    public interface IStatelessChain<T> {
        IStatelessChain<T> Run(T t);
    }
    public interface IStatefulChain<T> {
        T Item { get; }
        IStatefulChain<T> Run();
    }
    public interface IListener<T, U> {
        Func<T, U> Handle { get; } 
    }
    public interface ISomething<T> {
        T Item { get; set; }
    }
    public interface ISomethingImmutable<T> {
        T Item { get; }
    }
    public interface IDefault<T> {
        Func<T,T> orDefault { get; }
    }
    public interface ICurry<T> {
        Action<T> Create();
        Func<T, T> Create(T t1);
        Func<T, T> Create(T t1, T t2);
        Func<T, T> Create(T t1, T t2, T t3);
        Func<T, T> Create(T t1, T t2, T t3, T t4);
        Func<T, T> Create(T t1, T t2, T t3, T t4, T t5);
        Func<T, T> Create(T t1, T t2, T t3, T t4, T t5, T t6);
    }
    public interface ICurry1<T, U> {
        Func<Func<T, U>> Create { get; }
    }
    public interface ICurry2<T, U> {
        Func<T,Func<U, U>> Create { get; }
    }
    public enum LoggerKind { Null, Console, File, HttpPost, UI }
    public interface ILogManager {
        IEnumerable<ILogger> Loggers { get; }
        Task Log(string info);
        Task Log(LoggerKind kind, string info);
    }
    public interface ILogger : IDisposable {
        IEnumerable<LoggerKind> Kind { get; }
        Task ConfigureAsync(IDictionary<string, string> config);
        Task LogAsync(string info); 
    }
}
