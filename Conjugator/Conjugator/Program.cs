using System;
using System.IO;

namespace Conjugator
{
    class Program
    {
        const string nodeModulesPath = @"..\..\..\..\..\node_modules";
        static void Main(string[] args)
        {
            string verbsFileName = Path.Combine(nodeModulesPath, @"french-verbs-list\verbs.json");
            string frenchVerbsLefffName = Path.Combine(nodeModulesPath, @"french-verbs-lefff\dist\conjugations.json");
            var t = File.Exists(frenchVerbsLefffName);
            Console.WriteLine(t);
        }
    }
}
