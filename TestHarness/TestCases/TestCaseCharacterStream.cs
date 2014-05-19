using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
using Functional.Test;
using System.IO;

using Test.Contracts;
using Tests;
namespace Tests {

    [Export(typeof(IAsyncTestCase))]
    public class test_character_stream : IAsyncTestCase {
        private const string _Name = "test character stream";
        private const string _Description = "test character stream";
        public string TestFile { get { return "TestCaseCharacterStream.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            {
                byte[] buffer = Encoding.UTF8.GetBytes("hello world");

                MemoryStream memory_stream = new MemoryStream();
                IInputStream input_stream = new InputStream();
                memory_stream.Write(buffer, 0, buffer.Count());

                input_stream.Initialize(memory_stream);
                ICharacterStream cStream = new CharacterStream();
                cStream.Initialize(input_stream);

                ICharacter c1 = await cStream.Get();
                result = result && (null != c1); // ICharacterStream never returns null

                ICharacter ch = null;
                // verify that Get uses a pushed character
                cStream.Push(c1);
                ch = await cStream.Get();
                result = result && (c1.Info == ch.Info);

                while (ch.Kind != CharKind.NULL) ch = await cStream.Get();
                ch = await cStream.Get(); // verify that Get() continues to get the NULL
                result = result && (ch.Kind == CharKind.NULL);
                memory_stream.Dispose();
            }
            {
                byte[] buffer = Encoding.UTF8.GetBytes("\n");
                MemoryStream memory_stream = new MemoryStream();
                IInputStream input_stream = new InputStream();
                memory_stream.Write(buffer, 0, buffer.Count());

                input_stream.Initialize(memory_stream);
                ICharacterStream cStream = new CharacterStream();
                cStream.Initialize(input_stream);
                ICharacter ch = await cStream.Get();
                result = result && (ch.Kind == CharKind.CARRAGERETURN);
                ch = await cStream.Get();
                result = result && (ch.Kind == CharKind.NULL);
                memory_stream.Dispose();
            }
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_character_stream() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_CharacterStream);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_CharacterStream);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_chars);
        }
    }
}

