using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifPresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] {"aie", "aies", "ait", "ayons", "ayez", "aient"};
            }

            string[] endings = {"e", "es", "e", "ions", "iez", "ent"};

            return ApplyEndings(endings, verb);
        }

        private static string[] ApplyEndings(string[] endings, string verb)
        {
            try
            {
                var present = PresentConjugator.GetConjugations(verb);
                var nousForm = present[3];
                var stem = nousForm.TrimEnd("ons");

                return AddEndings(endings, stem);
            }
            catch (Exception ex)
            {
                return AddEndings(endings, verb.TrimEnd("ir"));
            }
        }

        private static string[] AddEndings(string[] endings, string modifiedStem, string nousVousStem)
        {
            return endings.MatchNousVous(s => modifiedStem + s, s => nousVousStem + s);
        }

        private static string[] AddEndings(string[] endings, string modifiedStem)
        {
            return endings.Select(ending => modifiedStem + ending).ToArray();
        }
    }
}