using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Conjugator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConjugatorTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string nodeModulesPath = @"..\..\..\..\..\node_modules";

        [TestMethod]
        public void TestMethod1()
        {
            string verbsFileName = Path.Combine(nodeModulesPath, @"french-verbs-list\verbs.json");
            string conjugationsFileName = Path.Combine(nodeModulesPath, @"french-verbs-lefff\dist\conjugations.json");

            var conjugations =
                JsonSerializer.Deserialize<Dictionary<string, Conjugation>>(File.ReadAllText(conjugationsFileName));

            int conjugatedVerbCount = conjugations.Count;

            var verbList = JsonSerializer.Deserialize<VerbList>(File.ReadAllText(verbsFileName));

            Verbs verbs = verbList.Verbs;
            int verbCount = verbs.FirstGroup.Length + verbs.SecondGroup.Length + verbs.ThirdGroup.Length;

            Console.WriteLine($"{conjugatedVerbCount} {verbCount}");
        }
    }
}
