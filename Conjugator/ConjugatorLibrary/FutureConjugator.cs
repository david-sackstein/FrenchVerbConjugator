﻿using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ConjugatorLibrary
{
    public static class FutureConjugator
    {
        public static readonly string[] endings = { "ai", "as", "a", "ons", "ez", "ont" };

        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);

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