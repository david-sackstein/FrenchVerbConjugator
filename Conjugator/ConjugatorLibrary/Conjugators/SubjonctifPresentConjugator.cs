﻿using System.Linq;

namespace ConjugatorLibrary
{
    public static class SubjonctifPresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "aller")
            {
                return new[] {"aille", "ailles", "aille", "allions", "alliez", "aillent" };
            }

            string[] endings = {"e", "es", "e", "ions", "iez", "ent"};
            string[] withEndings = ApplyEndings(endings, verb);

            // soften the c with a cedilla before an 'o' for nous (at index 3)
            if (verb[^3] == 'c')
            {
                withEndings[3] = withEndings[3].ReplaceAt(-4, 'ç');
            }

            return withEndings;
        }

        private static string[] ApplyEndings(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            // determine the stem for je, tu, il, ils ("modifiedStem") which may
            // not be the same as for nous and vous

            return PresentStemModifier.GetModifiedStem(stem, out string modifiedStem) 
                ? AddEndings(endings, modifiedStem, stem) 
                : AddEndings(endings, stem);
        }

        private static string[] AddEndings(string[] endings, string modifiedStem, string nousVousStem)
        {
            return endings.MatchNousVous(
                s => nousVousStem + s,
                s => modifiedStem + s
            );
        }

        private static string[] AddEndings(string[] endings, string modifiedStem)
        {
            return endings.Select(ending => modifiedStem + ending).ToArray();
        }
    }
}