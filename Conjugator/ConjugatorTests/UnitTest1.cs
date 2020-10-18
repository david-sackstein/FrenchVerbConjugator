using System;
using System.Collections.Generic;
using System.Linq;
using ConjugatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConjugatorTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string _nodeModulesPath = @"..\..\..\..\..\node_modules";
        private static VerbData _verbData;
        private static PresentConjugator _presentConjugator;
        private static ImparfaitConjugator _imparfaitConjugator;
        private static ParticipePasseConjugator _participePasseConjugator;
        private static FutureConjugator _futureConjugator;
        private static ConditionelConjugator _conditionelConjugator;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _verbData = new VerbData(_nodeModulesPath);
            _presentConjugator = new PresentConjugator();
            _imparfaitConjugator = new ImparfaitConjugator();
            _participePasseConjugator = new ParticipePasseConjugator();
            _futureConjugator = new FutureConjugator();
            _conditionelConjugator = new ConditionelConjugator();
        }

        [TestMethod]
        public void TestAllErPresent()
        {
            TestAll(v => _verbData.Conjugations[v].Present, _presentConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestAllErImparfait()
        {
            TestAll(v => _verbData.Conjugations[v].Imparfait, _imparfaitConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestAllParticipePasse()
        {
            TestAll(v => _verbData.Conjugations[v].ParticipePasse, _participePasseConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestAllFuture()
        {
            TestAll(v => _verbData.Conjugations[v].Future, _futureConjugator.GetConjugations);
        }

        [TestMethod]
        public void TestAllConditional()
        {
            TestAll(v => _verbData.Conjugations[v].Conditional, _conditionelConjugator.GetConjugations);
        }

        private static void TestAll(Func<string, string[]> referenceConjugator, Func<string, string[]> conjugator)
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

        #region Hidden 
        Conjugation FixPresentErConjugation(string verb, Conjugation input)
        {
            Conjugation output = new Conjugation();
            foreach (var property in typeof(Conjugation).GetProperties())
            {
                property.SetValue(output, property.GetValue(input));
            }
            output.Present = _presentConjugator.GetConjugations(verb);
            return output;
        }

        //[TestMethod]
        public void FixPresentErConjugations()
        {
            Dictionary<string, Conjugation> fixedConjugations = _verbData.Conjugations
                .Where(kv => kv.Key.EndsWith("er"))
                .ToDictionary(
                    kv => kv.Key,
                    kv => FixPresentErConjugation(kv.Key, kv.Value));

            VerbData.SaveConjugations(_nodeModulesPath, fixedConjugations);
        }
        #endregion
    }
}