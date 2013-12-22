using Tests;
using System;
namespace ConsoleTest
{

    public class Program
    {
       
        public static void Main(string[] args) {
            Action<string> output = text => Console.WriteLine(text);
            Func<string, bool,string> format = (text, result) => String.Format(text, result);

            ITestSuite functionalTests = new FunctionalTests();

            functionalTests.Initialize();

            foreach(test_case t in functionalTests.Tests) output(format("{0} "+t.Name, t.Run()));
        }
    }
}
