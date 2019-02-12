using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewEraSample.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var eras = new[] {'㍾', '㍽', '㍼', '㍻'};
            foreach (var era in eras)
            {
                Console.WriteLine(Char.GetUnicodeCategory(era)); // Others Symbols
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var eras = new[] {'㍾', '㍽', '㍼', '㍻', '㋿'};
            foreach (var era in eras)
            {
                string s = era.ToString();
                Console.WriteLine(s.Normalize(NormalizationForm.FormC));
                Console.WriteLine(s.Normalize(NormalizationForm.FormD));
                Console.WriteLine(s.Normalize(NormalizationForm.FormKC));
                Console.WriteLine(s.Normalize(NormalizationForm.FormKD));
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            IEnumerable<int> ToUtf32(string text)
            {
                for (var i = 0; i < text.Length; i += (char.IsSurrogate(text, i) ? 2 : 1))
                {
                    yield return char.ConvertToUtf32(text, i);
                }
            }

            var eras = new[] {'\u337e', '\u337d', '\u337c', '\u337b', '\u32ff'}; // '㍾', '㍽', '㍼', '㍻', '㋿'
            foreach (var era in eras)
            {
                string s = era.ToString();
                foreach (var form in Enum.GetNames(typeof(NormalizationForm)))
                {
                    var normalized = s.Normalize((NormalizationForm)Enum.Parse(typeof(NormalizationForm), form));
                    var codePoints = ToUtf32(normalized).Select(x => "U+" + x.ToString("X4"));
                    Console.WriteLine($"{form} : {normalized} ({string.Join(" ", codePoints)})");
                }
            }
        }
    }
}
