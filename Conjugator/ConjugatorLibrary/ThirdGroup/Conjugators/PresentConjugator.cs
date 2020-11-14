﻿using System.Collections.Generic;
using System.Linq;

namespace ConjugatorLibrary.ThirdGroup
{
    public static class PresentConjugator
    {
        private static readonly string[] _endings = new string[] {"s", "s", "t", "ons", "ez", "ent"};
        
        public static string[] GetConjugations(string verb)
        {
            if (verb == "suivre")
            {
                return ApplyEndings(_endings, "sui", "suiv");
            }
            
            if (verb.EndsWith("soudre"))
            {
                string stem = verb.TrimEnd("udre");
                return ApplyEndings(_endings, stem + "u", stem + "lv");
            }

            if (verb.EndsWith("ttre"))
            {
                string stem = verb.TrimEnd("ttre");
                return ApplyEndings(_endings, stem + "t", stem, stem + "tt");
            }

            if (verb.EndsWith("oître"))
            {
                var stem = verb.TrimEnd("ître");
                return ApplyEndings(_endings, stem + "i", stem + "î", stem + "iss");
            }
            
            if (verb.EndsWith("oindre"))
            {
                var stem = verb.TrimEnd("ndre");
                return ApplyEndings(_endings, stem + "n", stem + "gn");
            }
            

            string regularStem = verb.TrimEnd("re");
            if (regularStem[^1] == 'i')
            {
                string nousVousStem = regularStem.ReplaceEnd("i", "y");
                return _endings.AddEndings(regularStem, nousVousStem);
            }
            
            var withEndings = _endings.AddEndings(regularStem);
            return withEndings;
        }

        private static string[] ApplyEndings(string[] endings, string singleStem, string pluralStem)
        {
            return endings.Take(3).AddEndings(singleStem)
                .Concat(
                    endings.Skip(3).AddEndings(pluralStem)).ToArray();
        }
        
        private static string[] ApplyEndings(string[] endings, string singleStem, string ilStem, string pluralStem)
        {
            return endings.Take(2).AddEndings(singleStem)
                .Concat(endings.Skip(2).Take(1).AddEndings(ilStem))
                .Concat(endings.Skip(3).AddEndings(pluralStem)).ToArray();
        }
    }
}