using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ConjugatorLibrary
{
    public class FutureConjugator
    {
        public string[] GetErFuture(string verb)
        {
            Contract.Requires(verb != null && verb.Length > 2 && verb.EndsWith("er"));

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
            switch (verb)
            {
                case "aller":
                    return "ir";
                case "renvoyer":
                case "envoyer":
                    return verb.Replace("voyer", "verr");
                default:
                    return GetShortenedStem(verb) + "er";
            }
        }

        private static string GetShortenedStem(string verb)
        {
            string shortenedStem = verb[..^2];

            if (FutureStemConverter.GetModifiedStem(shortenedStem, out string modifiedStem))
            {
                return modifiedStem;
            }

            return shortenedStem;
        }

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}