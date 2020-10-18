using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ConjugatorLibrary
{
    public class FutureConjugator
    {
        public string[] GetErFuture(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));
            Contract.Requires(verb.Length > 2);

            if (verb == "agneler")
            {
                Console.WriteLine();
            }

            string stem = GetStem(verb);

            string[] endings = {"ai", "as", "a", "ons", "ez", "ont"};

            return AddEndings(endings, stem);
        }

        private static string GetStem(string verb)
        {
            if (verb == "aller")
            {
                return "ir";
            }
            if (verb == "renvoyer" || verb == "envoyer")
            {
                return verb.Replace("voyer", "verr");
            }

            if (FutureStemConverter.GetModifiedStem(verb.Substring(0, verb.Length - 2), out string modifiedStem))
            {
                return modifiedStem + "er";
            }
            return verb;
        }

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}