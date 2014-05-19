using System;
using System.Collections.Generic;
using Functional.Language.Contract.Core;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
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
                keyword = F.first<IToken>(tokens);
                IEnumerable<IToken> rest = F.rest<IToken>(tokens);
                var_name = F.first<IToken>(rest);
                rest = F.rest<IToken>(rest);
                var_type = F.first<IToken>(rest);
                rest = F.rest<IToken>(rest);
                end = F.first<IToken>(rest);
                Collision collision = Collision._none;
                if (VariableVerifier.Verify(var_name.Info, parser.Keywords, parser.Types, parser.Variables, ref collision)) {
                    if (TypeVerifier.Verify(var_type.Info, parser.Keywords, parser.Types, parser.Variables, ref collision)) {

                    } else tokenError("type", ref parseError, collision);
                } else tokenError("variable", ref parseError, collision);
            }
        }


        private static void tokenError(string what, ref IParseError parseError, Collision collision) {
            switch (collision) {
                case Collision._keyword:
                    parseError.Error = true;
                    parseError.ErrorInfo = String.Format("a keyword can not be used as a {0} name", what);
                    break;
                case Collision._type:
                    parseError.Error = true;
                    parseError.ErrorInfo = String.Format("a type can not be used as a {0} name", what);
                    break;
                case Collision._var:
                    parseError.Error = true;
                    parseError.ErrorInfo = String.Format("a variable can not be use as a {0} name", what);
                    break;
                case Collision._none:
                    parseError.Error = true;
                    parseError.ErrorInfo = String.Format("the {0} has invalid characters in it's name", what);
                    break;
            }
        }
        public static IExpression Create(IParser parser, IEnumerable<IToken> tokens, ref IParseError parseError) {
            return new DeclareExpression(parser, tokens, ref parseError);
        }
    }
}
