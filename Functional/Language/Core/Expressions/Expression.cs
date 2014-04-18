using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract;
using Functional.Language.Contract.Core;
using Functional.Language.Core.Expressions;
using Functional.Language.Contract.Parser;
using Functional.Implementation;

namespace FunctionalNET.Language.Core {
    public static class ExpressionBuilder {
        public static IBinaryExpression<bool, bool> CreateBinaryBooleanExpression<T>(Func<bool,bool,bool> fn, IExpression<bool> left, IExpression<bool> right) {
            
            return null;
        }
    }
}
