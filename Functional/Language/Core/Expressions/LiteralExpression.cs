using System;
using System.Collections.Generic;
using Functional.Language.Contract.Core;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;

namespace Functional.Language.Core.Expressions {
    public class LiteralExpression<T> : ILiteralExpression<T> {
        private IEnumerable<IToken> tokens;
        public IEnumerable<IToken> Tokens { get { return this.tokens; } }
        public bool IsLiteral { get { return true; } }

        public T Item { get; private set; }
        public Type BaseType { get { return typeof(T); } }
        public IExpression<T> Evaluate(IEvaluator ev, IContext context) { return (ILiteralExpression<T>) this; } //wtf
        public ILiteralExpression<T> GetLiteral(IEvaluator ev, IContext context) { return this; }
        private LiteralExpression() { }
        private LiteralExpression(IEnumerable<IToken> tokens, T n) {
            this.tokens = tokens;
            this.Item = n; 
        }
        public static ILiteralExpression<T> Create(IEnumerable<IToken> tokens, T n) { return new LiteralExpression<T>(tokens, n); }
    }
    public class LiteralEagerSequence<T> {
    }
}
