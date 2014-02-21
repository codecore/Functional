using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Implimentation;

using TestContracts;
using Tests;
namespace Tests {

    [Export(typeof(IAsyncTestCase))]
    public class test_character_stream : IAsyncTestCase {
        private const string _Name = "test character stream";
        private const string _Description = "test character stream";
        public string TestFile { get { return "TestCaseCharacterStream.cs"; } }
        public async Task<bool> RunAsync() {
            bool result = true;
            IInputStream inputStream = new InputStreamMock(3,"jiljsadfoi ajdn\nfkjn.*79\n498&<<[{mf] +==s kdjflij");
            IGetChar getChar = new GetChar();
            ICharacterStream characterStream = new CharacterStream();
            
            
            getChar.Initialize(inputStream);
            characterStream.Initialize(getChar);

            ICharacter c1 = await characterStream.Get();
            result = result && (null != c1); // ICharacterStream never returns null
            
            ICharacter ch = null;
            // verify that Get uses a pushed character
            characterStream.Push(c1);
            ch = await characterStream.Get();
            result = result && (c1.Info == ch.Info);
            
            while (ch.Kind != CharKind.NULL) ch = await characterStream.Get();
            ch = await characterStream.Get(); // verify that Get() continues to get the NULL
            result = result && (ch.Kind == CharKind.NULL);

            inputStream = new InputStreamMock(1, "\n");
            getChar.Initialize(inputStream);
            characterStream.Initialize(getChar);

            ch = await characterStream.Get();
            result = result && (ch.Kind == CharKind.CARRAGERETURN);
            ch = await characterStream.Get();
            result = result && (ch.Kind == CharKind.NULL);
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

