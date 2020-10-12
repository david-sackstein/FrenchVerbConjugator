using System;
using System.Linq;
using ConjugatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConjugatorTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string nodeModulesPath = @"..\..\..\..\..\node_modules";
        private static VerbData verbData;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            verbData = new VerbData(nodeModulesPath);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string verb = "manger";

            Conjugation conjugation = verbData.Conjugations[verb];
            string[] expected = conjugation.Present;

            string[] actual = new Conjugator().GetErPresent(verb);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
