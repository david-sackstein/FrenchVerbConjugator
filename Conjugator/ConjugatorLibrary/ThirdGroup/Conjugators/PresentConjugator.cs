using System;
using System.Collections.Generic;
using System.Linq;

namespace ConjugatorLibrary.ThirdGroup
{
    public static class PresentConjugator
    {
        private static readonly string[] _endings = new string[] {"s", "s", "t", "ons", "ez", "ent"};
        private static readonly string[] _endings1 = new string[] {"s", "s", "", "ons", "ez", "ent"};
        
        public static string[] GetConjugations(string verb)
        {
            if (verb == "suivre")
            {
                return ApplyEndings(_endings, "sui", "suiv");
            }

          
            if (verb.EndsWith("endre"))
            {
                string[] verbs =
                {
                    "apprendre", "comprendre", "déprendre", "désapprendre",
                    "entreprendre", "méprendre", "prendre", "rapprendre",
                    "reprendre", "réapprendre", "surprendre", "éprendre"
                };

                if (verbs.Contains(verb))
                {
                    string stem = verb.TrimEnd("dre");
                    return ApplyEndings1(_endings1, stem + "d", stem, stem+"n");
                }

                string regularStem1 = verb.TrimEnd("re");
                return _endings1.AddEndings(regularStem1);
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

            if (verb.EndsWith("aître"))
            {
                var stem = verb.TrimEnd("ître");
                return ApplyEndings(_endings, stem + "i", stem + "î", stem + "iss");
            }

            if (verb.EndsWith("oître"))
            {
                var stem = verb.TrimEnd("ître");
                return ApplyEndings(_endings, stem + "i", stem + "î", stem + "iss");
            }
            
            if (verb.EndsWith("oindre") || verb.EndsWith("eindre"))
            {
                var stem = verb.TrimEnd("ndre");
                return ApplyEndings(_endings, stem + "n", stem + "gn");
            }

            if (verb.EndsWith("ire") && ! verb.EndsWith("aire") && ! verb.EndsWith("oire"))
            {
                string stem = verb.TrimEnd("re");
                return ApplyEndings(_endings, stem, stem + "s");
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

        private static string[] ApplyEndings1(string[] endings, string singleStem, string nousVousStem, string ilsStem)
        {
            return endings.Take(3).AddEndings(singleStem)
                .Concat(endings.Skip(3).Take(2).AddEndings(nousVousStem))
                .Concat(endings.Skip(5).AddEndings(ilsStem)).ToArray();
        }

        private static string[] ApplyEndings(string[] endings, string singleStem, string pluralStem)
        {
            return endings.Take(3).AddEndings(singleStem)
                .Concat(endings.Skip(3).AddEndings(pluralStem)).ToArray();
        }
        
        private static string[] ApplyEndings(string[] endings, string singleStem, string ilStem, string pluralStem)
        {
            return endings.Take(2).AddEndings(singleStem)
                .Concat(endings.Skip(2).Take(1).AddEndings(ilStem))
                .Concat(endings.Skip(3).AddEndings(pluralStem)).ToArray();
        }
    }
}