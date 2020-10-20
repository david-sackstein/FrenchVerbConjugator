using System;
using System.Collections.Generic;
using System.Linq;
using ConjugatorLibrary.Conjugators;
using ConjugatorLibrary.FirstGroup;
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
            _conjugator = new FirstGroupConjugator();
        }

        [TestMethod]
        public void TestErPresent()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Present, _conjugator.Present);
        }

        [TestMethod]
        public void TestErImparfait()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Imparfait, _conjugator.Imparfait);
        }

        [TestMethod]
        public void TestErParticipePasse()
        {
            TestErVerbs(v => _verbData.Conjugations[v].ParticipePasse, _conjugator.ParticipePasse);
        }

        [TestMethod]
        public void TestErParticipePresent()
        {
            TestErVerbs(v => _verbData.Conjugations[v].ParticipePresent, _conjugator.ParticipePresent);
        }

        [TestMethod]
        public void TestErFuture()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Future, _conjugator.Future);
        }

        [TestMethod]
        public void TestErConditional()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Conditional, _conjugator.Conditionel);
        }

        [TestMethod]
        public void TestErImperatif()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Imperatif, _conjugator.Imperatif);
        }

        [TestMethod]
        public void TestErSubjonctifPresentConjugator()
        {
            TestErVerbs(v => _verbData.Conjugations[v].SubjonctifPresent, _conjugator.SubjonctifPresent);
        }

        [TestMethod]
        public void TestErSubjonctifImparfaitConjugator()
        {
            TestErVerbs(v => _verbData.Conjugations[v].SubjonctifImparfait, _conjugator.SubjonctifImparfait);
        }

        [TestMethod]
        public void TestErPasseSimpleConjugator()
        {
            TestErVerbs(v => _verbData.Conjugations[v].PasseSimple, PasseSimpleConjugator.GetConjugations);
        }

        private static void TestErVerbs(Func<string, string[]> referenceConjugator, Func<string, string[]> conjugator)
        {
            Dictionary<bool, string[]> grades = _verbData.Conjugations.Keys
                .Where(v => v.EndsWith("er"))
                .GroupBy(v => IsCorrect(v, referenceConjugator, conjugator))
                .ToDictionary(g => g.Key, g => g.ToArray());

            string[] expectedErrors = ErrorList.Load();
            string[] actualErrors = grades.ContainsKey(false) ? grades[false] : new string[0];

            string[] newErrors = actualErrors.Except(expectedErrors).ToArray();
            string[] newFixes = expectedErrors.Except(actualErrors).ToArray();

            Assert.IsTrue(!newErrors.Any());

            //Console.WriteLine($"{actualErrors.Length} errors");
            //ErrorList.Save(actualErrors, referenceConjugator, conjugator);
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
                return tuple.expected == null || tuple.expected == "NA" || tuple.expected == tuple.actual;
            }

            return expected == null ||
                   expected.Length == actual.Length &&
                   expected.Zip(actual).All(Equal);
        }
    }
}