
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functional.Implementation;
using TestHarness;
using Test.Contracts;

using Functional.Contracts;
using Functional.Utility;
using Functional.Test;

namespace ConsoleTest
{

    public class Program
    {
        public Singleton<IExtensibilityHost, ExtensibilityHost> nothing;
        public static void Main(string[] args) {
            ITestHarness testharness = harness.Create();
            
            CompositionCode code = Singleton<IExtensibilityHost, ExtensibilityHost>.Instance.SatisfyImports(testharness);
            if (code == CompositionCode.Success) {

                Action<string> output = text => Console.WriteLine(text);
                Func<string, bool, string> format = (text, result) => String.Format(text, result);

                output.Invoke("getting the testcases");
                
                output.Invoke("composed");

                RunSelectedTests(testharness.SyncTests, testharness.AsyncTests, TestCoverage.F_T_sort_merge);

            }


            Singleton<IExtensibilityHost, ExtensibilityHost>.Instance.Dispose();
        }
        public static void RunSelectedTests(IEnumerable<ISyncTestCase> syncTests, IEnumerable<IAsyncTestCase> asyncTests, int sel) {
            IEnumerable<IAsyncTestCase> selectedAsyncTests = F<IAsyncTestCase>.filter(asyncTests, x => F<int>.any(x.Feature, n => n == sel));
            IEnumerable<ISyncTestCase> selectedSyncTests = F<ISyncTestCase>.filter(syncTests, x => F<int>.any(x.Feature, n => n == sel));
            foreach (IAsyncTestCase test in selectedAsyncTests) {
                Task.WaitAll(test.RunAsync());
            }
            foreach (ISyncTestCase test in selectedSyncTests) {
                test.Run();
            }
        }
    }
}
