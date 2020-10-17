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

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _verbData = new VerbData(_nodeModulesPath);
            _presentConjugator = new PresentConjugator();
            _imparfaitConjugator = new ImparfaitConjugator();
        }

        Conjugation FixPresentErConjugation(string verb, Conjugation input)
        {
            Conjugation output = new Conjugation();
            foreach (var property in typeof(Conjugation).GetProperties())
            {
                property.SetValue(output, property.GetValue(input));
            }
            output.Present = _presentConjugator.GetErPresent(verb);
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

        [TestMethod]
        public void TestAllErPresent()
        {
            Dictionary<bool, string[]> grades = _verbData.Conjugations.Keys
                .Where(v => v.EndsWith("er"))
                .GroupBy(IsErPresentCorrect)
                .ToDictionary(g => g.Key, g => g.ToArray());

            string[] expectedErrors = ErrorList.Load();
            string[] actualErrors = grades.ContainsKey(false) ? grades[false] : new string[0];

            var newErrors = actualErrors.Except(expectedErrors).ToArray();
            var newFixes = expectedErrors.Except(actualErrors).ToArray();

            Assert.IsTrue(!newErrors.Any());

            Console.WriteLine($"{actualErrors.Length} errors");
            //ErrorList.Save(actualErrors, _verbData.Conjugations);
        }

        [TestMethod]
        public void TestAllErImparfait()
        {
            Dictionary<bool, string[]> grades = _verbData.Conjugations.Keys
                .Where(v => v.EndsWith("er"))
                .GroupBy(IsErImparfaitCorrect)
                .ToDictionary(g => g.Key, g => g.ToArray());

            string[] expectedErrors = ErrorList.Load();
            string[] actualErrors = grades.ContainsKey(false) ? grades[false] : new string[0];

            var newErrors = actualErrors.Except(expectedErrors).ToArray();
            var newFixes = expectedErrors.Except(actualErrors).ToArray();

            //Assert.IsTrue(!newErrors.Any());

            Console.WriteLine($"{actualErrors.Length} errors");
            ErrorList.Save(actualErrors, _verbData.Conjugations);
        }

        private static bool IsErPresentCorrect(string verb)
        {
            Conjugation conjugation = _verbData.Conjugations[verb];
            string[] expected = conjugation.Present;
            string[] actual = _presentConjugator.GetErPresent(verb);
            return 
                expected == null || 
                expected.Zip(actual)
                    .All(tuple => tuple.First == null || tuple.First == tuple.Second);
        }

        private static bool IsErImparfaitCorrect(string verb)
        {
            Conjugation conjugation = _verbData.Conjugations[verb];
            string[] expected = conjugation.Imparfait;
            string[] actual = _imparfaitConjugator.GetErImparfait(verb);
            return
                expected == null ||
                expected.Zip(actual)
                    .All(tuple => tuple.First == null || tuple.First == tuple.Second);
        }
    }
}