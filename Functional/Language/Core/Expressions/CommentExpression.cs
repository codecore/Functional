using System;
using System.Collections.Generic;
using Functional.Language.Contract.Core;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;

namespace Functional.Language.Core.Expressions {
    public class CommentExpression : IExpression {
        private IEnumerable<IToken> tokens;
        public IEnumerable<IToken> Tokens { get { return this.tokens; } }
        public Type BaseType { get { return typeof(NOOP); } }
        private CommentExpression(){}
        private CommentExpression(IEnumerable<IToken> tokens) { this.tokens = tokens; }
        public static IExpression Create(IEnumerable<IToken> tokens) {
            return new CommentExpression(tokens);
        }
    }
}
