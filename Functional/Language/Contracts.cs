using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract.Core;
using Functional.Language.Contract.Editor;
using Functional.Language.Contract.Parser;

namespace Functional.Language.Contract {
    public enum InputStreamKind { Mock, File }
    public interface IInputStream : IDisposable {
        InputStreamKind Kind { get; }
        Task Initialize(string filename);
        Task<string> ReadLine();
        bool EOF { get; }
    }
    public interface IMemoryManagement<T> {
        T New();
        void Delete(T t);
    }
    public class function : object {
        public object fun { get; private set; }
        public Type type { get; private set; }
        public void Set<T>(Func<T> fn) { this.fun = fn; this.type = typeof(Func<T>); }
        public void Set<T>(Func<T,T> fn) { this.fun = fn; this.type = typeof(Func<T,T>); }
        public void Set<T>(Func<T,T,T> fn) { this.fun = fn; this.type = typeof(Func<T,T,T>); }
        public void Set<T,U>(Func<T,U> fn) { this.fun = fn; this.type = typeof(Func<T,U>); }
        public void Set<T,U>(Func<T,T,U> fn) { this.fun = fn; this.type = typeof(Func<T,T,U>); }
    }  
}


