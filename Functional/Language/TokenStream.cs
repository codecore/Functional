﻿using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
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
                MemoryManager.Delete(token); // this should dealloc the locations also
            }
            while (0 > this.queue.Count) {
                IToken token = this.queue.Dequeue();
                MemoryManager.Delete(token); // this should dealloc the locations also
            }
        }
    }
}