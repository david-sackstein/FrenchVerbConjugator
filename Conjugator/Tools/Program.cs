using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ConjugatorLibrary;

namespace Tools
{
    internal class Program
    {
        private const string _nodeModulesPath = @"..\..\..\..\..\node_modules";

        private static void Main(string[] args)
        {
            var beforeFix = GetConjugations("conjugations.json");
            var afterFix = GetConjugations("conjugations-fixed.json");
            string[] newVerbs = beforeFix.Keys.Except(afterFix.Keys).ToArray();
            var best = afterFix.Concat(beforeFix.Where(kv => newVerbs.Contains(kv.Key)))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
            SaveConjugations(_nodeModulesPath, beforeFix, "conjugations.json");
            SaveConjugations(_nodeModulesPath, best, "conjugations-fixed.json");
            Console.WriteLine();
        }

        private static Dictionary<string, Conjugation> GetConjugations(string name)
        {
            string conjugationsFileName = Path.Combine(
                _nodeModulesPath, @$"french-verbs-lefff\dist\{name}");

            return LoadConjugations(conjugationsFileName);
        }

        private static Dictionary<string, Conjugation> LoadConjugations(string fileName)
        {
            return JsonSerializer.Deserialize<Dictionary<string, Conjugation>>(
                File.ReadAllText(fileName));
        }

        public static void SaveConjugations(string nodeModulesPath, Dictionary<string, Conjugation> conjugations, string name)
        {
            string text = JsonSerializer.Serialize(conjugations, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            });

            string conjugationsFileName = Path.Combine(
                nodeModulesPath, $@"french-verbs-lefff\dist\{name}");

            File.WriteAllText(conjugationsFileName, text);
        }
    }
}