using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class TokenStream : ITokenStream {
        private Stack<IToken> stack = new Stack<IToken>();
        private Queue<IToken> queue = new Queue<IToken>();
        public void Put(IToken token) { this.queue.Enqueue(token); }
        public void Push(IToken token) { this.stack.Push(token); }
        public IToken Get() {
            IToken token = null;
            if (0 < this.stack.Count) token = this.stack.Pop();
            else if (0 < this.queue.Count) token = this.queue.Dequeue();
            return token;
        }
        public void Clear() {
            while (0 > this.stack.Count) {
                IToken token = this.stack.Pop();
            }
            while (0 > this.queue.Count) {
                IToken token = this.queue.Dequeue();
            }
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (IToken token in this.stack) sb.Append(token.ToString());
            foreach (IToken token in this.queue) sb.Append(token.ToString());
            return sb.ToString();
        }
    }
}
