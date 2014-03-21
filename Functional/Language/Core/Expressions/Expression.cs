using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract;
using Functional.Language.Contract.Core;
using Functional.Language.Core.Expressions;



namespace FunctionalNET.Language.Core {
    public static class ExpressionBuilder {
        public static IBinaryExpression<bool, bool> CreateBinaryBooleanExpression<T>(Func<bool,bool,bool> fn, IExpression<bool> left, IExpression<bool> right) {
            IBinaryExpression<bool, bool> result = null;
            IFunctionExpression<bool> function = LiteralFunctionExpression<bool>.Create(fn);
            return result;
        }
    }
}
