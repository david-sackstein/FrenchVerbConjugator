using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ConjugatorLibrary;

namespace ConjugatorTests
{
    static class ErrorList
    {
        private const string errorFileName = @"..\..\..\errors.txt";

        public static void Save(string[] errorVerbs, Dictionary<string, Conjugation> conjugations)
        {
            string[][] errorVerbsWith = errorVerbs.Select(verb => Flatten(verb, conjugations)).ToArray();
            Save(errorVerbsWith);
        }

        public static string[] Load()
        {
            return LoadWithConjugations().Select(c => c[0]).ToArray();
        }

        public static string[][] LoadWithConjugations()
        {
            var text = File.ReadAllText(errorFileName);
            return JsonSerializer.Deserialize<string[][]>(text);
        }

        private static string[] Flatten(string verb, Dictionary<string, Conjugation> conjugations)
        {
            string[] conjugation = conjugations[verb].Present ?? new string[0];
            return new[] { verb }.Concat(conjugation).ToArray();
        }

        private static void Save(string[][] errorVerbs)
        {
            var errors = JsonSerializer.Serialize(errorVerbs, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            });
            File.WriteAllText(errorFileName, errors);
        }
    }
}
