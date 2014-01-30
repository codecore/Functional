
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functional.Implementation;
using TestHarness;
using TestContracts;
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

                Console.WriteLine("getting the testcases");
                
                Console.WriteLine("composed");
                IEnumerable<bool> results = testharness.Results();
                Console.WriteLine("results");
                IEnumerable<ITestCase> selectedTests = F<ITestCase>.filter(testharness.Tests, x => F<int>.any(x.Feature, n => n == TestCoverage.F_T_iterate_while));
                foreach (ITestCase test in selectedTests) {
                    bool b = test.Run(); Console.WriteLine("{0} {1}", b, test.Name);
                }
                //Task<bool[]> allTasks = Task.WhenAll(results);
                

            }


            Singleton<IExtensibilityHost, ExtensibilityHost>.Instance.Dispose();
        }
    }
}
