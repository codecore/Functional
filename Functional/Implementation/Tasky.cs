using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts.Utility;
using Functional.Contracts;
using Functional.Test;

namespace Functional.Implementation {
    public interface IChannel<T> {
        void Send(T message);
        bool Receive(out T message);
    }
    public class Channel<T> : IChannel<T> {
        private Queue<T> messages = new Queue<T>();
        public void Send(T message) { this.messages.Enqueue(message); }
        public bool Receive(out T message) {
            bool result = (0 < this.messages.Count);
            message = (result) ? this.messages.Dequeue() : default(T);
            return result;
        }
    }

    public interface IMessage<T> {
        IAgent<IMessage<T>> Source { get; }
        T Info { get; }
    }
    public class Message<T> : IMessage<T> {
        public IAgent<IMessage<T>> Source { get; private set; }
        public T Info { get; private set; }
        public Message(T info,IAgent<IMessage<T>> agent=null) { this.Source = agent; this.Info = info; }
    }

    public delegate Yield Yield();
    public interface IAgent<T> {
        Yield Start();
        void Send(T message);
        Yield Receive(Func<T, Yield> continuation);
    }
    public class Scheduler {
        private bool toggle = true;
        private IList<Yield> Ying = new List<Yield>();
        private IList<Yield> Yang = new List<Yield>();
        private static int RunAndCopy(ref IList<Yield> target, ref IList<Yield> source) {
            int count = 0;
            target.Clear();
            foreach (Yield y in source) {
                Yield result = y.Invoke();
                if (null != result) {
                    target.Add(result);
                    count++;
                }
            }
            return count;
        }
        public int TimeSlice() {
            int count = (this.toggle) ? RunAndCopy(ref this.Yang, ref this.Ying) : RunAndCopy(ref this.Ying, ref this.Yang);
            this.toggle = !this.toggle;
            return count;
        }
        public void Add(Yield y) {
            if (this.toggle) this.Ying.Add(y); else this.Yang.Add(y);
        }
    }

}
