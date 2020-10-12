using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ConjugatorLibrary;

namespace ConjugatorTests
{
    class VerbData
    {
        public Verbs Verbs { get; }
        public Dictionary<string, Conjugation> Conjugations { get; }

        public VerbData(string nodeModulesPath)
        {
            string verbsFileName = Path.Combine(
                nodeModulesPath, @"french-verbs-list\verbs.json");
            
            string conjugationsFileName = Path.Combine(
                nodeModulesPath, @"french-verbs-lefff\dist\conjugations.json");

            Conjugations = JsonSerializer.Deserialize<Dictionary<string, Conjugation>>(
                File.ReadAllText(conjugationsFileName));
            
            var verbList = JsonSerializer.Deserialize<VerbList>(
                File.ReadAllText(verbsFileName));

            Verbs = verbList.Verbs;
        }
    }
}