using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Contract.Editor;
using Functional.Language.Contract;
using Functional.Contracts.Utility;
using Functional.Language.Contract.Core;
using Functional.Language.Implimentation;
using Functional.Implementation;
using Functional.Language.Core.Expressions;

namespace Functional.Language.Implimentation {
    [Export(typeof(IExpressionParser))]
    public class CommentExpressionParser : ICommentExpressionParser {
        public string Keyword { get { return keywords.comment; } }
        // return null if this token isn't for this expression parser
        public IExpression Parse(IParser parser, IStream<IToken> tokenStream, ref IParseError parseError) {
            IExpression commentExpression = null;
            IList<IToken> tokens = new List<IToken>();
            IToken token = tokenStream.Get(); // the first is the keyword
            if ((token.Kind == TokenKind.UnquotedWord) && (token.Info == keywords.comment)) {
                while ((token.Kind != TokenKind.NULL) && (!((token.Kind == TokenKind.UnquotedWord) && (token.Info == keywords.end)))) {
                    tokens.Add(token);
                    token = tokenStream.Get();
                }
                tokens.Add(token);
                commentExpression = CommentExpression.Create(tokens);
            } else tokenStream.Push(token);
            return commentExpression;
        }
    }
}
