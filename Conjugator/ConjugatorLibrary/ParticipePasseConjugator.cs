using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ConjugatorLibrary
{
    public class ParticipePasseConjugator
    {
        public string[] GetParticiplePasse(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));
            Contract.Requires(verb.Length > 2);

            if (verb == "béer")
            {
                Console.WriteLine();
            }
            string stem = GetStem(verb);

            string[] endings = { "é", "és", "ée", "ées" };
            string[] withEndings = AddEndings(endings, stem);
            return withEndings;
        }

        private static string GetStem(string verb)
        {
            if (verb == "aller")
            {
                return "all";
            }
            return verb.Remove(verb.Length - 2);
        }

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}