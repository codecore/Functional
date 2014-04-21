using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts.Utility;
using Functional.Contracts;
using Functional.Test;

namespace Functional.Implementation {

    public class StatelessChain<T> : IStatelessChain<T> {
        // TestCoverage = Chain
        private Action<T> action = (t) => {};
        private Func<T, bool> predicate = (t) => true;
        private StatelessChain(Func<T, bool> pred, Action<T> a = null) {
            this.action = (a != null) ? a : (t) => { };
            this.predicate = pred;
        }
        /// <summary>Run action(t) if predicate(t)</summary><returns>IStatelessChain if predicate(t) is true, else null</returns>in.
        [Coverage(TestCoverage.Chain)]
        public IStatelessChain<T> Run(T t) {
            bool do_this = this.predicate(t);
            if (do_this) this.action(t);
            return (do_this) ? this : null;
        }

        /// <summary>Takes a predicate ans an optional action</summary><returns>IStatelessChain</returns>
        public static IStatelessChain<T> Create(Func<T,bool> predicate, Action<T> a = null) { return new StatelessChain<T>(predicate,a); }

    }
    public class StatelessChain<T, U> : IStatelessChain<T, U> {
        private Action<T, U> action = (t, u) => { };
        private Func<T, U, bool> predicate = (t, u) => true;
        private StatelessChain(Func<T, U, bool> pred, Action<T, U> a = null) {
            this.action = (a != null) ? a : (t, u) => { };
            this.predicate = pred;
        }
        /// <summary>Run action(t) if predicate(t)</summary><returns>IStatelessChain if predicate(t) is true, else null</returns>in.
        [Coverage(TestCoverage.Chain)]
        public IStatelessChain<T, U> Run(T t, U u) {
            bool do_this = this.predicate(t, u);
            if (do_this) this.action(t, u);
            return (do_this) ? this : null;
        }
        public static IStatelessChain<T, U> Create(Func<T, U, bool> predicate, Action<T, U> a = null) { 
            return new StatelessChain<T, U>(predicate, a); 
        }
    }
    public class StatelessChain<T, U, V> : IStatelessChain<T, U, V> {
        private Action<T, U, V> action = (t, u, v) => { };
        private Func<T, U, V, bool> predicate = (t, u, v) => true;
        private StatelessChain(Func<T, U, V, bool> pred, Action<T, U, V> a = null) {
            this.action = (a != null) ? a : (t, u, v) => { };
            this.predicate = pred;
        }
        /// <summary>Run action(t) if predicate(t)</summary><returns>IStatelessChain if predicate(t) is true, else null</returns>in.
        [Coverage(TestCoverage.Chain)]
        public IStatelessChain<T, U, V> Run(T t, U u, V v) {
            bool do_this = this.predicate(t, u, v);
            if (do_this) this.action(t, u, v);
            return (do_this) ? this : null;
        }
        public static IStatelessChain<T, U, V> Create(Func<T, U, V, bool> predicate, Action<T, U, V> a = null) {
            return new StatelessChain<T, U, V>(predicate, a);
        }
    }
    public class StatefulChain<T> : IStatefulChain<T> {
        private Action<T> action = null;
        private Func<T, T> trans = null;
        private Func<T, bool> predicate = null;

        public T Item { get; private set; }
        private StatefulChain(Func<T, bool> pred, Action<T> a, Func<T, T> tr, T t) {
            this.action = a;
            this.predicate = pred;
            this.trans = tr;
            this.Item = t;
        }
        /// <summary>if predicate(state) calls action, and updates state</summary><returns>IStatefulChain if predicate(state), else null</returns>
        [Coverage(TestCoverage.Chain)]
        public IStatefulChain<T> Run() {
            IStatefulChain<T> result = null;
            if (null != this.trans) {
                bool do_this = this.predicate(this.Item);
                if (do_this) {
                    this.action(this.Item);
                    this.Item = this.trans(this.Item);
                    result = this;
                }
            }
            return result; 
        }
        /// <summary>Takes a predicate and an action and a transform and an initial item of T</summary><returns>IStatefulChain</returns>
        public static IStatefulChain<T> Create(Func<T, bool> predicate, Action<T> a, Func<T, T> tr, T item) {
            return new StatefulChain<T>(predicate, a, tr, item);
        }
    }
    public static partial class F<T> {
        [Coverage(TestCoverage.Chain)]
        public static IStatelessChain<T> Run(IStatelessChain<T> item, T t) {
            return item.Run(t);
        }
        [Coverage(TestCoverage.Chain)]
        public static IStatelessChain<T,U> Run<U>(IStatelessChain<T,U> item, T t, U u) {
            return item.Run(t,u);
        }
        [Coverage(TestCoverage.Chain)]
        public static IStatelessChain<T,U,V> Run<U,V>(IStatelessChain<T,U,V> item, T t, U u, V v) {
            return item.Run(t, u, v);
        }
        [Coverage(TestCoverage.Chain)]
        public static IStatefulChain<T> Run(IStatefulChain<T> item) {
            return item.Run();
        }
    }
}