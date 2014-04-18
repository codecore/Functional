using System;
using System.Collections.Generic;
using Functional.Language.Contract.Core;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Implementation;

namespace Functional.Language.Core.Expressions {
    public class DeclareExpression : IExpression {
        private IEnumerable<IToken> tokens;
        public IEnumerable<IToken> Tokens { get { return this.tokens; } }
        public Type BaseType { get { return typeof(NOOP); } }
        private DeclareExpression(){}
        private DeclareExpression(IParser parser, IEnumerable<IToken> tokens, ref IParseError parseError) { 
            this.tokens = tokens; 
            IToken keyword, var_name, var_type, end;
            int count = F.count<IToken>(tokens);
            if (count == 4) { // declare name type end
                int index = 0;
                foreach (IToken token in tokens) {
                    if (0 == index) keyword = token;
                    if (1 == index) var_name = token;
                    if (2 == index) var_type = token;
                    if (3 == index) end = token;
                    index++;
                }
            }  

        }
        public static IExpression Create(IParser parser, IEnumerable<IToken> tokens, ref IParseError parseError) {
            return new DeclareExpression(parser, tokens, ref parseError);
        }
    }
}
