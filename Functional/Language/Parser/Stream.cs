using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Contracts.Utility;
using Functional.Language.Contract.Parser;
namespace Functional.Utility  {
    public class Stream<T> : IStream<T> {
        private Stack<T> stack = new Stack<T>();
        private Queue<T> queue = new Queue<T>();
        private IEnumerable<T> enumerable = null;
        private IEnumerator<T> enumerator = null;
        public void Dispose() {
            if (null != this.enumerator) {
                this.enumerator.Dispose();
                this.enumerator = null;
            }
            this.stack.Clear();
            this.queue.Clear();
        }
        public void Put(T token) { this.queue.Enqueue(token); }
        public void Push(T token) { this.stack.Push(token); }
        public void Set(IEnumerable<T> seq) {
            this.enumerable = seq;
            this.enumerator = this.enumerable.GetEnumerator();
        }
        public T Get() {
            T token = default(T);
            if (0 < this.stack.Count) token = this.stack.Pop();
            else if (0 < this.queue.Count) token = this.queue.Dequeue();
            else {
                if (null != this.enumerator) {
                    if (this.enumerator.MoveNext()) token = this.enumerator.Current;
                } else if (null != this.enumerable) {
                    if (null != this.enumerator) {
                        this.enumerator.Dispose();
                        this.enumerator = null;
                    }
                    this.enumerator = this.enumerable.GetEnumerator();
                    if (this.enumerator.MoveNext()) token = this.enumerator.Current;
                }
            }
            return token;
        }
        public void Clear() {
            this.Dispose();
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (IToken token in this.stack) sb.Append(token.ToString());
            foreach (IToken token in this.queue) sb.Append(token.ToString());
            return sb.ToString();
        }
    }
}
