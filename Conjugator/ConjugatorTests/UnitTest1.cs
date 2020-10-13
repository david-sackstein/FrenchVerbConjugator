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
        private static Conjugator _conjugator;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _verbData = new VerbData(_nodeModulesPath);
            _conjugator = new Conjugator();
        }

        [TestMethod]
        public void TestMangerPresent()
        {
            string verb = "manger";
            TestErPresent(verb);
        }

        [TestMethod]
        public void TestAllErPresent()
        {
            Dictionary<bool, string[]> grades = _verbData.Conjugations.Keys
                .Where(v => v.EndsWith("er"))
                .GroupBy(IsCorrect)
                .ToDictionary(g => g.Key, g => g.ToArray());

            string[] expectedErrors = ErrorList.Load();
            string[] actualErrors = grades[false];

            var newErrors = actualErrors.Except(expectedErrors).ToArray();
            var newFixes = expectedErrors.Except(actualErrors).ToArray();

            foreach (var newError in newErrors)
            {
                ShowError(newError);
            }
            //Assert.IsTrue(!newErrors.Any());

            //ErrorList.Save(grades[false]);

            var firstFailure = grades[false][0];
            ShowError(firstFailure);
        }

        private static void ShowError(string verb)
        {
            Conjugation conjugation = _verbData.Conjugations[verb];
            string[] expected = conjugation.Present;
            string[] actual = _conjugator.GetErPresent(verb);
            Console.WriteLine($"{verb}:\n");
            for (int i = 0; i < expected.Length; i++)
            {
                string incorrect = actual[i] == expected[i] ? "" : "x";
                Console.WriteLine($"{expected[i]}\n{actual[i]} {incorrect}\n");
            }
        }

        private static bool IsCorrect(string verb)
        {
            Conjugation conjugation = _verbData.Conjugations[verb];
            string[] expected = conjugation.Present;
            string[] actual = _conjugator.GetErPresent(verb);
            return expected != null && expected.SequenceEqual(actual);
        }

        private static void TestErPresent(string verb)
        {
            Conjugation conjugation = _verbData.Conjugations[verb];
            string[] expected = conjugation.Present;

            string[] actual = new Conjugator().GetErPresent(verb);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}