using System;

using Functional.Contracts;
using Functional.Test;

namespace Functional.Implementation {
    public class Curry<T, U> : ICurry<T, U> {
        private Func<T, T, U> fn;
        private Curry() { }
        public Curry(Func<T, T, U> fun) {
            this.fn = fun;
            this.Create = (t) => (x) => this.fn(t, x);
        }
        [Coverage(TestCoverage.Curry_curry)]
        public Func<T, Func<T, U>> Create { get; private set; }
    }
    public class Curry1<T, U> : ICurry1<T, U> {
        private Func<T, U> fn;
        private Curry1(){}
        public Curry1(Func<T, U> fun) {
            this.fn = fun;
            this.Create = () => (x) => this.fn(x);
        }
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        [Coverage(TestCoverage.Curry_curry1)]
        public Func<Func<T, U>> Create { get; private set; } 
    }
    public class Curry2<T, U> : ICurry2<T, U> {
        private Func<T, U, U> fn; // U fn(T t, U u)
        public Curry2(Func<T, U, U> fun) {
            this.fn = fun; 
            this.Create = (t) => (x) => this.fn(t, x);
        }
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        [Coverage(TestCoverage.Curry_curry2)]
        public Func<T,Func<U, U>> Create { get; private set; }
    }

    public class CurryMonster<T> : ICurry<T> { //TODO needs test coverage
        private const string INVALID = "invalid";
        private enum Which {
            _fn_1_1,
            _fn_2_1,
            _fn_3_1,
            _fn_4_1,
            _fn_5_1,
            _fn_6_1,
            _fn_7_1
        }
        private Which which;
        
        private Func<T,T> fn_1_1;
        private Func<T,T,T> fn_2_1;
        private Func<T,T,T,T> fn_3_1;
        private Func<T,T,T,T,T> fn_4_1;
        private Func<T,T,T,T,T,T> fn_5_1;
        private Func<T,T,T,T,T,T,T> fn_6_1;
        private Func<T, T,T,T,T,T,T,T> fn_7_1;
        public CurryMonster(Func<T,T> fun) {
            this.which = Which._fn_1_1;
            this.fn_1_1 = fun;
        }
        public CurryMonster(Func<T,T,T> fun) {
            this.which = Which._fn_2_1;
            this.fn_2_1 = fun;
        }
        public CurryMonster(Func<T,T,T,T> fun) {
            this.which = Which._fn_3_1;
            this.fn_3_1 = fun;
        }
        public CurryMonster(Func<T,T,T,T,T> fun) {
            this.which = Which._fn_4_1;
            this.fn_4_1 = fun;
        }
        public CurryMonster(Func<T,T,T,T,T,T> fun) {
            this.which = Which._fn_5_1;
            this.fn_5_1 = fun;
        }
        public CurryMonster(Func<T,T,T,T,T,T,T> fun) {
            this.which = Which._fn_6_1;
            this.fn_6_1 = fun;
        }
        public CurryMonster(Func<T,T,T,T,T,T,T,T> fun) {
            this.which = Which._fn_7_1;
            this.fn_7_1 = fun;
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Action<T> Create() {
            if (this.which != Which._fn_1_1) throw new Exception(INVALID);
            return (t) => this.fn_1_1(t);
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T,T> Create(T t1) {
            if (this.which != Which._fn_2_1) throw new Exception(INVALID);
            return (t) => this.fn_2_1(t, t1);
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T,T> Create(T t1, T t2) {
            if (this.which != Which._fn_3_1) throw new Exception(INVALID);
            return (t) => this.fn_3_1(t, t1, t2);
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T,T> Create(T t1, T t2, T t3) {
            if (this.which != Which._fn_4_1) throw new Exception(INVALID);
            return (t) => this.fn_4_1(t, t1, t2, t3);
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T, T> Create(T t1, T t2, T t3, T t4) {
            if (this.which != Which._fn_5_1) throw new Exception(INVALID);
            return (t) => this.fn_5_1(t, t1, t2, t3, t4);
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T, T> Create(T t1, T t2, T t3,T t4,T t5) {
            if (this.which != Which._fn_6_1) throw new Exception(INVALID);
            return (t) => this.fn_6_1(t, t1, t2, t3,t4,t5);
        }
        [Coverage(TestCoverage.Curry_monster)]
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T, T> Create(T t1, T t2, T t3,T t4,T t5,T t6) {
            if (this.which != Which._fn_7_1) throw new Exception(INVALID);
            return (t) => this.fn_7_1(t, t1, t2, t3, t4, t5, t6);
        }
    }
}