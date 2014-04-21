using System;
using System.Collections.Generic;

using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Contracts.Utility;

namespace Functional.Language.Contract.Core {
    public class NOOP : Object { }
    public interface IContext { } // the runtime state
    public interface IEvaluator {
        string LastError { get; }
        void Error(string s);
        IExpression Evaluate<T,U>(IBinaryExpression<T,U> ex, IContext context);
    }

    public interface IBinaryExpression<T,U> : IExpression<T> { // TODO <U,V>
        IExpression<T> Left { get; }
        IExpression<T> Right { get; }
        IBinaryFunctionExpression<T,U> Function { get; }
    }
    public interface IExpression {
        Type BaseType { get; }
        IEnumerable<Functional.Language.Contract.Parser.IToken> Tokens { get; }
    }
    public interface IExpression<T> : IExpression {
        IExpression<T> Evaluate(IEvaluator ev, IContext context);
        bool IsLiteral { get; }
    }
    public interface ILiteralExpression<T> : IExpression<T> {
        T Item { get; }
    }
    public interface ISequence<T> : IExpression<T> { }
    public interface IEagerSequence<T> : ISequence<T> { }
    public interface ILazySequence<T> : ISequence<T> { }
    public interface ILiteralEagerSequence<T> : IEagerSequence<T> {
        IEnumerable<T> Items { get; }
        void Add(T item); // really
    }
    public interface ILiteralLazySequence<T> : ILazySequence<T> {
        IEnumerable<T> Items { get; }
    }
    public interface IFunctionExpression<T> : IExpression {
        IFunctionExpression<T> Evaluate(IEvaluator ev, IContext context);
        bool IsLiteral { get; }
    }
    public interface IFunctionExpression<T, U> : IExpression {
        IFunctionExpression<T,U> Evaluate(IEvaluator ev, IContext context);
        bool IsLiteral { get; }
    }
    public interface ILiteralFunctionExpression<T> : IFunctionExpression<T> {

        IExpression Invoke(T t1);
        IExpression Invoke(T t1,T t2);
        IExpression Invoke(T t1, T t2, T t3);
        IExpression Invoke(IEnumerable<T> e);
        IExpression Invoke(Func<T> fn);
        Func<T> f_t { get; }
        Func<T, T> f_t_t { get; }
        Func<T, T, T> f_t_t_t { get; }
        Func<T, T, T, T> f_t_t_t_t { get; }

        Func<IEnumerable<T>, T> f_et_t { get; }

        Func<Func<T>, T> ft_t { get; }
        Func<Func<T>, Func<T>> f_f { get; }
        Func<Func<T>> f { get; }
    }
    public interface ILiteralFunctionExpression<T, U> : IFunctionExpression<T,U> {
        IExpression Invoke(T t1, U u1);
        IExpression Invoke(IEnumerable<T> e);
        IExpression Invoke(Func<T> fn);
    }
    public interface IBinaryFunctionExpression<T, U> : IFunctionExpression<T, U> { }
    public interface ILiteralBinaryFunctionExpression<T, U> : IBinaryFunctionExpression<T, U> {
        IExpression Invoke(T t1, T t2);
    }
    public interface ITransformFunctionExpression<T, U> : IFunctionExpression<T, U> { }
    public interface ILiteralTransformFunctionExpression<T, U> : ITransformFunctionExpression<T, U> {
        IExpression Invoke(T t1);
    }

    public interface IParseError {
        bool Error { get; set; }
        string ErrorInfo { get; set; }
    }

    public interface IDecerator {
    }

    public interface IExpressionParser {
        string Keyword { get; }
        IExpression Parse(IParser parser, IStream<IToken> tokenParser,ref IParseError parseError);
    }
    public interface IDeclareExpressionParser : IExpressionParser {
    }
    public interface ICommentExpressionParser : IExpressionParser {
    }
}
