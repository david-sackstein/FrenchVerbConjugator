using System.Collections.Generic;
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
            if (verb == "absoudre")
            {
                return ApplyEndings(_endings, "absou", "absolv");
            }

            if (verb == "abattre")
            {
                return ApplyEndings(_endings, "abat", "aba", "abatt");
            }
           

            string stem = verb.TrimEnd("re");
            var withEndings = _endings.AddEndings(stem);
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