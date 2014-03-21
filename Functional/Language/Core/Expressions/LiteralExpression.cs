using System;

using Functional.Language.Contract.Core;
using Functional.Language.Contract;

namespace Functional.Language.Core.Expressions {
    public class LiteralExpression<T> : ILiteralExpression<T> {
        public bool IsLiteral { get { return true; } }

        public T Item { get; private set; }
        public Type BaseType { get { return typeof(T); } }
        public IExpression<T> Evaluate(IEvaluator ev, IContext context) { return (ILiteralExpression<T>) this; } //wtf
        public ILiteralExpression<T> GetLiteral(IEvaluator ev, IContext context) { return this; }
        private LiteralExpression() { }
        private LiteralExpression(T n) { this.Item = n; }
        public static ILiteralExpression<T> Create(T n) { return new LiteralExpression<T>(n); }
    }
    public class LiteralEagerSequence<T> {
    }
}
