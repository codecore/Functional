using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract.Parser;
namespace Functional.Language.Implimentation {
    public class ParserContext  : IParserContext {
        private ParserContext() { }
        private IList<Type> knownTypes = new List<Type>();
        public IEnumerable<Type> KnownTypes { get { return this.knownTypes; } }
        public void Add(Type type) {
            if (!this.knownTypes.Contains(type)) this.knownTypes.Add(type);
        }
        public static IParserContext Create() {
            return new ParserContext();
        }
    }
}
