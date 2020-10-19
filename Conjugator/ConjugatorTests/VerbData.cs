using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ConjugatorLibrary;

namespace ConjugatorTests
{
    internal class VerbData
    {
        public Verbs Verbs { get; }
        public Dictionary<string, Conjugation> Conjugations { get; }

        public VerbData(string nodeModulesPath)
        {
            string verbsFileName = Path.Combine(
                nodeModulesPath, @"french-verbs-list\verbs.json");

            string conjugationsFileName = Path.Combine(
                nodeModulesPath, @"french-verbs-lefff\dist\conjugations-fixed.json");

            Conjugations = LoadConjugations(conjugationsFileName);

            var verbList = JsonSerializer.Deserialize<VerbList>(
                File.ReadAllText(verbsFileName));

            Verbs = verbList.Verbs;
        }

        private static Dictionary<string, Conjugation> LoadConjugations(string fileName)
        {
            return JsonSerializer.Deserialize<Dictionary<string, Conjugation>>(
                File.ReadAllText(fileName));
        }

        public static void SaveConjugations(string nodeModulesPath, Dictionary<string, Conjugation> conjugations)
        {
            string text = JsonSerializer.Serialize(conjugations, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            });

            string conjugationsFileName = Path.Combine(
                nodeModulesPath, @"french-verbs-lefff\dist\conjugations-fixed.json");

            File.WriteAllText(conjugationsFileName, text);
        }
    }
}