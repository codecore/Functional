using System;
using System.Collections.Generic;

using Functional.Language.Contract.Core;
using Functional.Language.Contract;

namespace Functional.Language.Core.Expressions {
    public class LiteralFunctionExpression<T> : ILiteralFunctionExpression<T> {
        public bool IsLiteral { get { return true; } }
        public Type BaseType { get { return mytype; } }
        private Type mytype = typeof(function);
        public IFunctionExpression<T> Evaluate(IEvaluator ev, IContext context){ return (IFunctionExpression<T>)this; }
        public ILiteralFunctionExpression<T> GetLiteral(IEvaluator ev, IContext context) { return this; }
        public Func<T> f_t { get; private set; }
        public Func<T,T> f_t_t { get; private set; }
        public Func<T,T,T> f_t_t_t { get; private set; }
        public Func<T,T,T,T> f_t_t_t_t { get; private set; }

        public Func<IEnumerable<T>, T> f_et_t { get; private set; }

        public Func<Func<T>, T> ft_t { get; private set; }
        public Func<Func<T>, Func<T>> f_f { get; private set; }
        public Func<Func<T>> f { get; private set; }


        public IExpression Invoke() {
            IExpression result = null;
            if (null != this.f_t) result = LiteralExpression<T>.Create(this.f_t.Invoke());
            else if (null != this.f) result = LiteralFunctionExpression<T>.Create(this.f.Invoke());
            return result;
        }
        public IExpression Invoke(T t1) { return (null != this.f_t_t) ? LiteralExpression<T>.Create(this.f_t_t.Invoke(t1)) : null; }
        public IExpression Invoke(T t1, T t2) { return (null != this.f_t_t_t) ? LiteralExpression<T>.Create(this.f_t_t_t.Invoke(t1,t2)) : null; }
        public IExpression Invoke(T t1, T t2, T t3) { return (null != this.f_t_t_t_t) ? LiteralExpression<T>.Create(this.f_t_t_t_t.Invoke(t1, t2, t3)) : null; }
        public IExpression Invoke(IEnumerable<T> e) { return (null != this.f_et_t) ? LiteralExpression<T>.Create(this.f_et_t.Invoke(e)) : null; }
        public IExpression Invoke(Func<T> fn) {
            IExpression result = null;
            if (null != this.ft_t) result = LiteralExpression<T>.Create(this.ft_t.Invoke(fn));
            else if (null != this.f_f) result = LiteralFunctionExpression<T>.Create(this.f_f.Invoke(fn));
            return result;
        }

        private LiteralFunctionExpression(Func<T> fn) {
            this.mytype = typeof(Func<T>);
            this.f_t = fn; 
        }
        private LiteralFunctionExpression(Func<T,T> fn) {
            this.mytype = typeof(Func<T,T>);
            this.f_t_t = fn; 
        }
        private LiteralFunctionExpression(Func<T,T,T> fn) {
            this.mytype = typeof(Func<T,T,T>);
            this.f_t_t_t = fn; 
        }
        private LiteralFunctionExpression(Func<T,T,T,T> fn) {
            this.mytype = typeof(Func<T,T,T,T>);
            this.f_t_t_t_t = fn; 
        }
        private LiteralFunctionExpression(Func<IEnumerable<T>, T> fn) {
            this.mytype = typeof(Func<IEnumerable<T>,T>);
            this.f_et_t = fn;
        }
        private LiteralFunctionExpression(Func<Func<T>,T> fn) {
            this.mytype = typeof(Func<Func<T>,T>);
            this.ft_t = fn; 
        }
        private LiteralFunctionExpression(Func<Func<T>> fn) {
            this.mytype = typeof(Func<Func<T>>);
            this.f = fn;
        }
        public static ILiteralFunctionExpression<T> Create(Func<T> fn) { return new LiteralFunctionExpression<T>(fn); }
        public static ILiteralFunctionExpression<T> Create(Func<T,T> fn) { return new LiteralFunctionExpression<T>(fn); }
        public static ILiteralFunctionExpression<T> Create(Func<T,T,T> fn) { return new LiteralFunctionExpression<T>(fn); }
        public static ILiteralFunctionExpression<T> Create(Func<IEnumerable<T>,T> fn) { return new LiteralFunctionExpression<T>(fn); }
        public static ILiteralFunctionExpression<T> Create(Func<Func<T>,T> fn) { return new LiteralFunctionExpression<T>(fn); }
        public static ILiteralFunctionExpression<T> Create(Func<Func<T>> fn) { return new LiteralFunctionExpression<T>(fn); }

    }


    public class LiteralFunctionExpression<T,U> : ILiteralFunctionExpression<T,U> {
        public bool IsLiteral { get { return true; } }
        public Type BaseType { get { return this.mytype; } }
        private Type mytype = typeof(function);
        public IFunctionExpression<T,U> Evaluate(IEvaluator ev, IContext context) { return (ILiteralFunctionExpression<T,U>)this; }
        public ILiteralFunctionExpression<T,U> GetLiteral(IEvaluator ev, IContext context) { return this; }

        private Func<T,T,U> f_t_t_u;
        private Func<T,U,T> f_t_u_t;

        private Func<IEnumerable<T>, U> f_et_u;

        private Func<Func<T>, U> ft_u;
        private Func<Func<T>, Func<U>> f_u;




        public IExpression Invoke(T t1, U u1) {
            return (null != this.f_t_u_t) ? LiteralExpression<T>.Create(this.f_t_u_t.Invoke(t1, u1)) : null;
        }
        public IExpression Invoke(IEnumerable<T> e) {
            return (null != this.f_et_u) ? LiteralExpression<U>.Create(this.f_et_u.Invoke(e)) : null; 
        }
        public IExpression Invoke(Func<T> fn) {
            IExpression result = null;
            if (null != this.ft_u) result = LiteralExpression<U>.Create(this.ft_u.Invoke(fn));
            else if (null != this.f_u) result = LiteralFunctionExpression<U>.Create(this.f_u.Invoke(fn));
            return result;
        }

        private LiteralFunctionExpression(Func<T,T,U> fn) {
            this.mytype = typeof(Func<T,T,U>);
            this.f_t_t_u = fn;
        }
        private LiteralFunctionExpression(Func<T,U,T> fn) {
            this.mytype = typeof(Func<T,U,T>);
            this.f_t_u_t = fn;
        }
        private LiteralFunctionExpression(Func<IEnumerable<T>,U> fn) {
            this.mytype = typeof(Func<IEnumerable<T>,U>);
            this.f_et_u = fn;
        }
        private LiteralFunctionExpression(Func<Func<T>,U> fn) {
            this.mytype = typeof(Func<Func<T>,U>);
            this.ft_u = fn;
        }
   
        public static ILiteralFunctionExpression<T, U> Create(Func<T,U,T> fn) { return new LiteralFunctionExpression<T,U>(fn); }
        public static ILiteralFunctionExpression<T, U> Create(Func<IEnumerable<T>,U> fn) { return new LiteralFunctionExpression<T,U>(fn); }
        public static ILiteralFunctionExpression<T, U> Create(Func<Func<T>,U> fn) { return new LiteralFunctionExpression<T,U>(fn); }
    }
    public class LiteralBinaryFunctionExpression<T, U> : ILiteralBinaryFunctionExpression<T, U> {
        public bool IsLiteral { get { return true; } }
        public Type BaseType { get { return this.mytype; } }
        public IFunctionExpression<T, U> Evaluate(IEvaluator ev, IContext context) { return (IFunctionExpression<T, U>)this; }
        public ILiteralFunctionExpression<T, U> GetLiteral(IEvaluator ev, IContext context) { return (ILiteralFunctionExpression<T, U>)this; }
        public IExpression Invoke(T t1, T t2) {
            return LiteralExpression<U>.Create(this.fun.Invoke(t1, t2));
        }
        private Type mytype = typeof(function);
        private Func<T,T,U> fun = (t1,t2) => default(U);
        private LiteralBinaryFunctionExpression() { }
        private LiteralBinaryFunctionExpression(Func<T, T, U> fn) { this.fun = fn; this.mytype = typeof(Func<T, T, U>); }
        public static ILiteralBinaryFunctionExpression<T, U> Create(Func<T, T, U> fn) { return new LiteralBinaryFunctionExpression<T, U>(fn); }
    }
    public class LiteralTransformFunctionExpression<T, U> : ILiteralTransformFunctionExpression<T, U> {
        public bool IsLiteral { get { return true; } }
        public Type BaseType { get { return this.mytype; } }
        public IFunctionExpression<T, U> Evaluate(IEvaluator ev, IContext context) { return (IFunctionExpression<T, U>)this; }
        public ILiteralFunctionExpression<T, U> GetLiteral(IEvaluator ev, IContext context) { return (ILiteralFunctionExpression<T, U>)this; }
        private Type mytype = typeof(function);
        private Func<T, U> fun = (t1) => default(U);
        private LiteralTransformFunctionExpression() { }
        private LiteralTransformFunctionExpression(Func<T, U> fn) { this.fun = fn; this.mytype = typeof(Func<T, U>); }
        public IExpression Invoke(T t1) {
            return LiteralExpression<U>.Create(this.fun.Invoke(t1));
        }
        public static ILiteralTransformFunctionExpression<T, U> Create(Func<T, U> fn) { return new LiteralTransformFunctionExpression<T, U>(fn); }
    }
}
