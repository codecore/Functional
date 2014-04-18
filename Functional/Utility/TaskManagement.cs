using System;
//using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Functional.Implementation;

namespace Functional.Utility {
    public class ThrottledService {
        static void Main(string[] args) {
            var task = DoSampleWork();
            task.Wait();
        }

        private static int currentTaskCount = 0;
        private static Random randomizer = new Random((int)DateTime.Now.Ticks);
        private readonly string[] sayings = {
            "Hello World",
            "See your future, Be your future",
            "You can't go. All the plants are gonna die",
            "so I got that going for me, which is nice",
            "It's in the hole"
        };
        private static int totalTasks = 0;
        static async Task DoSampleWork() {
            var engine = new ThrottledService();
            var allTasks = new List<Task<string>>();
            for (int i = 0; i < 20; i++) {
                allTasks.Add(engine.ProducePithySaying());
                await Task.Delay(250);
            }
            foreach (var task in allTasks) {
                try {
                    Console.WriteLine(await task);
                } catch (InvalidOperationException) {
                    Console.WriteLine("This task failed");
                }
            }
        }
        static async Task DoThrottledSampleWork(int concurrencyLevel) {
            var engine = new ThrottledService();
            const int CONCURRENCY_LEVEL = 5;
            int nextIndex = 0;
            var throttledTasks = new List<Task<string>>();
            while (nextIndex < CONCURRENCY_LEVEL && nextIndex < 20) {
                throttledTasks.Add(engine.ProducePithySaying());
                nextIndex++;
            }
            while (throttledTasks.Count > 0) {
                try {
                    Task<string> finishedTask = await Task.WhenAny(throttledTasks);
                    throttledTasks.Remove(finishedTask);
                    Console.WriteLine(await finishedTask);
                } catch (Exception exc) {
                    Console.WriteLine(exc.ToString());
                }
                if (nextIndex < 20) {
                    throttledTasks.Add(engine.ProducePithySaying());
                    nextIndex++;
                }
            }
        }
        public async Task<string> ProducePithySaying() {
            totalTasks++;
            if (currentTaskCount > 4) throw new InvalidOperationException("Can only perform 5 concurrent operations");
            System.Threading.Interlocked.Increment(ref currentTaskCount);
            string rVal = string.Format("starting task {0}, {1} now ", totalTasks.ToString(), currentTaskCount.ToString());
            int delay = randomizer.Next(250, 5000);
            await Task.Delay(delay);
            System.Threading.Interlocked.Decrement(ref currentTaskCount);
            rVal += " " + sayings[randomizer.Next(sayings.Length - 1)];
            rVal += " delayed " + delay.ToString();
            return rVal;
        }
    }
    public class TaskManager {
        private int maxConcurrency = 5;
        private int runningTaskCount = 0;
        private int waitingTaskCount = 0;
        private int totalTasks = 0;
        private IList<Task> running = new List<Task>();
        private IList<Task> waiting = new List<Task>();
        public async Task DoThrottledWork(IEnumerable<Task> tasks, int concurrency) {
            this.maxConcurrency = concurrency;
            IEnumerator<Task> enumTasks = tasks.GetEnumerator();
            while(enumTasks.MoveNext()) {
                if (this.runningTaskCount < this.maxConcurrency) { 
                    this.running.Add(enumTasks.Current); 
                    this.runningTaskCount++;
                } else { 
                    this.waiting.Add(enumTasks.Current);
                    this.waitingTaskCount++;
                }
            }
            while (this.running.Count > 0) {
                try {
                    Task finished = await Task.WhenAny(this.running);
                    running.Remove(finished);
                } catch (Exception) { }
                if (this.waiting.Count > 0) {
                    Task first = this.waiting[0];
                    this.waiting.RemoveAt(0);
                    running.Add(first);
                }
            }
        }
        public async Task doSomething() {
            //System.Threading.Interlocked.Increment(ref this.currentTaskCount);
            await Task.Delay(0);
            //System.Threading.Interlocked.Decrement(ref this.currentTaskCount);
        }
    }
}
