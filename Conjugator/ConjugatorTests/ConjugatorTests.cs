using System;
using System.Collections.Generic;
using System.Linq;
using ConjugatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConjugatorTests
{
    [TestClass]
    public class ConjugatorTests
    {
        private const string _nodeModulesPath = @"..\..\..\..\..\node_modules";
        private static VerbData _verbData;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _verbData = new VerbData(_nodeModulesPath);
        }

        [TestMethod]
        public void TestErPresent()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Present, PresentConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestErImparfait()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Imparfait, ImparfaitConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestErParticipePasse()
        {
            TestErVerbs(v => _verbData.Conjugations[v].ParticipePasse, ParticipePasseConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestErFuture()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Future, FutureConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestErConditional()
        {
            TestErVerbs(v => _verbData.Conjugations[v].Conditional, ConditionelConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestErParticipePresent()
        {
            TestErVerbs(v => _verbData.Conjugations[v].ParticipePresent, ParticipePresentConjugator.GetConjugations);
        }

        private static void TestErVerbs(Func<string, string[]> referenceConjugator, Func<string, string[]> conjugator)
        {
            Dictionary<bool, string[]> grades = _verbData.Conjugations.Keys
                .Where(v => v.EndsWith("er"))
                .GroupBy(v => IsCorrect(v, referenceConjugator, conjugator))
                .ToDictionary(g => g.Key, g => g.ToArray());

            string[] expectedErrors = ErrorList.Load();
            string[] actualErrors = grades.ContainsKey(false) ? grades[false] : new string[0];

            var newErrors = actualErrors.Except(expectedErrors).ToArray();
            var newFixes = expectedErrors.Except(actualErrors).ToArray();

            //Assert.IsTrue(!newErrors.Any());

            Console.WriteLine($"{actualErrors.Length} errors");
            ErrorList.Save(actualErrors, referenceConjugator, conjugator);
        }

        private static bool IsCorrect(
            string verb, 
            Func<string, string[]> referenceConjugator, 
            Func<string, string[]> conjugator)
        {
            string[] expected = referenceConjugator(verb);
            string[] actual = conjugator(verb);
            return
                expected == null ||
                expected.Zip(actual)
                    .All(tuple => tuple.First == null || tuple.First == tuple.Second);
        }
    }
}