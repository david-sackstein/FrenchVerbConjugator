using System;
using System.Collections.Generic;
using System.Linq;
using ConjugatorLibrary.Conjugators;
using ConjugatorLibrary.SecondGroup;
using ConjugatorLibrary.ThirdGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConjugatorTests
{
    [TestClass]
    public class ConjugatorTests
    {
        private const string _nodeModulesPath = @"..\..\..\..\..\node_modules";
        private static VerbData _verbData;
        private static IConjugator _conjugator;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _verbData = new VerbData(_nodeModulesPath);
            //_conjugator = new FirstGroupConjugator();
            //_conjugator = new SecondGroupConjugator();
            _conjugator = new ThirdGroupConjugator();
        }

        [TestMethod]
        public void TestImparfait()
        {
            TestConjugator(v => _verbData.Conjugations[v].Imparfait, _conjugator.Imparfait);
        }

        [TestMethod]
        public void TestParticipePasse()
        {
            TestConjugator(v => _verbData.Conjugations[v].ParticipePasse, _conjugator.ParticipePasse);
        }

        [TestMethod]
        public void TestParticipePresent()
        {
            TestConjugator(v => _verbData.Conjugations[v].ParticipePresent, _conjugator.ParticipePresent);
        }

        [TestMethod]
        public void TestFuture()
        {
            TestConjugator(v => _verbData.Conjugations[v].Future, _conjugator.Future);
        }

        [TestMethod]
        public void TestConditional()
        {
            TestConjugator(v => _verbData.Conjugations[v].Conditional, _conjugator.Conditionel);
        }

        [TestMethod]
        public void TestImperatif()
        {
            TestConjugator(v => _verbData.Conjugations[v].Imperatif, _conjugator.Imperatif);
        }

        [TestMethod]
        public void TestSubjonctifPresentConjugator()
        {
            TestConjugator(v => _verbData.Conjugations[v].SubjonctifPresent, _conjugator.SubjonctifPresent);
        }

        [TestMethod]
        public void TestSubjonctifImparfaitConjugator()
        {
            TestConjugator(v => _verbData.Conjugations[v].SubjonctifImparfait, _conjugator.SubjonctifImparfait);
        }

        [TestMethod]
        public void TestPasseSimpleConjugator()
        {
            TestConjugator(v => _verbData.Conjugations[v].PasseSimple, _conjugator.PasseSimple);
        }

        [TestMethod]
        public void TestPresent()
        {
            TestConjugator(v => _verbData.Conjugations[v].Present, _conjugator.Present);
        }

        private static void TestConjugator(
            Func<string, string[]> referenceConjugator,
            Func<string, string[]> conjugator)
        {
            Dictionary<bool, string[]> grades = _verbData.Conjugations.Keys
                .Where(_conjugator.IsInGroup)
                .GroupBy(v => IsCorrect(v, referenceConjugator, conjugator))
                .ToDictionary(g => g.Key, g => g.ToArray());

            string[] expectedErrors = ErrorList.Load();
            string[] actualErrors = grades.ContainsKey(false) ? grades[false] : new string[0];

            string[] newErrors = actualErrors.Except(expectedErrors).ToArray();
            string[] newFixes = expectedErrors.Except(actualErrors).ToArray();

            if (actualErrors.Any())
            {
                Console.WriteLine($"{actualErrors.Length} errors");
                ErrorList.Save(actualErrors, referenceConjugator, conjugator);
                Assert.Fail();
            }
        }

        private static bool IsCorrect(
            string verb,
            Func<string, string[]> referenceConjugator,
            Func<string, string[]> conjugator)
        {
            string[] expected = referenceConjugator(verb);
            string[] actual = conjugator(verb);

            bool Equal((string expected, string actual) tuple)
            {
                return tuple.expected == null || 
                       tuple.expected == "NA" || 
                       tuple.expected == tuple.actual;
            }

            bool isCorrect = expected == null ||
                 expected.Length == actual.Length &&
                 expected.Zip(actual).All(Equal);

            if (! isCorrect)
            {
                if (verb.EndsWith("endre"))
                {
                    Console.WriteLine(verb);
                }
                return false;
            }
            return true;
        }
    }
}