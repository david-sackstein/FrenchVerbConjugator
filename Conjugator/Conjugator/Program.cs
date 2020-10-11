using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Conjugator
{
    internal class Program
    {
        private const string nodeModulesPath = @"..\..\..\..\..\node_modules";

        private static void Main(string[] args)
        {
            string verbsFileName = Path.Combine(nodeModulesPath, @"french-verbs-list\verbs.json");
            string conjugationsFileName = Path.Combine(nodeModulesPath, @"french-verbs-lefff\dist\conjugations.json");

            var conjugations =
                JsonSerializer.Deserialize<Dictionary<string, Conjugation>>(File.ReadAllText(conjugationsFileName));

            var verbs = JsonSerializer.Deserialize<VerbList>(File.ReadAllText(verbsFileName));
        }
    }
}