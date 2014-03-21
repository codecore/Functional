using System;

using Functional.Language.Contract.Core;
using Functional.Language.Contract;
using Functional.Language.Core.Expressions;

namespace Functional.Language.Core {
    public class Interpreter : IEvaluator {
        public Interpreter() { this.LastError = String.Empty; }
        public string LastError { get; private set; }
        public void Error(string s) { this.LastError = s; }
        private ILiteralExpression<T> get<T>(IExpression<T> expression, IEvaluator ev, IContext context) {
            IExpression<T> ex = expression;
            while (!ex.IsLiteral) ex = ex.Evaluate(this, context);
            return ex as ILiteralExpression<T>;
        }
        private ILiteralFunctionExpression<T> get<T>(IFunctionExpression<T> expression, IEvaluator ev, IContext context) {
            IFunctionExpression<T> ex = expression;
            while (!ex.IsLiteral) ex = ex.Evaluate(this, context);
            return ex as ILiteralFunctionExpression<T>;
        }
        private ILiteralFunctionExpression<T,U> get<T,U>(IFunctionExpression<T,U> expression, IEvaluator ev, IContext context) {
            IFunctionExpression<T,U> ex = expression;
            while (!ex.IsLiteral) ex = ex.Evaluate(this, context);
            return ex as ILiteralFunctionExpression<T,U>;
        }
        private ILiteralBinaryFunctionExpression<T, U> get<T, U>(IBinaryFunctionExpression<T, U> expression, IEvaluator ev, IContext context) {
            IFunctionExpression<T, U> ex = expression;
            while (!ex.IsLiteral) ex = ex.Evaluate(this, context);
            return ex as ILiteralBinaryFunctionExpression<T, U>;
        }
        public IExpression Evaluate<T,U>(IBinaryExpression<T,U> ex, IContext context) {
            IBinaryFunctionExpression<T,U> TheFunction = ex.Function;
            ILiteralExpression<T> literalLeft = this.get<T>(ex.Left, this, context);
            ILiteralExpression<T> literalRight = this.get<T>(ex.Right, this, context);
            ILiteralBinaryFunctionExpression<T, U> literalBinaryFunction = this.get<T, U>(ex.Function, this, context);
            return literalBinaryFunction.Invoke(literalLeft.Item, literalRight.Item);
        }
    }
}
