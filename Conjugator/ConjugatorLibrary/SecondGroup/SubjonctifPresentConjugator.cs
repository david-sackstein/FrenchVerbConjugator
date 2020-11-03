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

                if (verb == "savoir")
                {
                    return new[] {"sache", "saches", "sache", "sachions", "sachiez", "sachent"};
                }

                if (verb.EndsWith("enir"))
                {
                    string stem = verb.TrimEnd("enir");
                    var nousVousStem = stem + "en";
                    var nonNousVousStem = stem + "ienn";
                    return AddEndings(endings, nonNousVousStem, nousVousStem);
                }
                if (verb.EndsWith("quérir"))
                {
                    string stem = verb.TrimEnd("érir");
                    var nousVousStem = stem + "ér";
                    var nonNousVousStem = stem + "ièr";
                    return AddEndings(endings, nonNousVousStem, nousVousStem);
                }
                if (verb.EndsWith("cevoir"))
                {
                    string stem = verb.TrimEnd("cevoir");
                    var nousVousStem = stem + "cev";
                    var nonNousVousStem = stem + "çoiv";
                    return AddEndings(endings, nonNousVousStem, nousVousStem);
                }

                if (verb.EndsWith("devoir"))
                {
                    string stem = verb.TrimEnd("devoir");
                    var nousVousStem = stem + "dev";
                    var nonNousVousStem = stem + "doiv";
                    return AddEndings(endings, nonNousVousStem, nousVousStem);
                }
                if (verb == "pleuvoir")
                {
                    //"émouvoir",
                    //"émeuve              émouve",
                    //"émeuves             émouves",
                    //"émeuve              émouve",
                    //"émouvions           émouvions",
                    //"émouviez            émouviez",
                    //"émeuvent            émouvent"
                    string stem = verb.TrimEnd("oir");
                    return AddEndings(endings, stem);
                }

                if (verb == "voir")
                {
                    string stem = verb.TrimEnd("ir");
                    var nousVousStem = stem + "y";
                    var nonNousVousStem = stem + "i";
                    return AddEndings(endings, nonNousVousStem, nousVousStem);
                    //"voir",
                    //"voie                voye",
                    //"voies               voyes",
                    //"voie                voye",
                    //"voyions             voyions",
                    //"voyiez              voyiez",
                    //"voient              voyent"

                }
                else
                {
                    string stem = nousForm.TrimEnd("ons");
                    return AddEndings(endings, stem);
                }

            }
            catch (Exception ex)
            {
                return AddEndings(endings, verb.TrimEnd("ir"));
            }
        }

        private static string[] AddEndings(string[] endings, string stem, string nousVousStem)
        {
            return endings.MatchNousVous(s => stem + s, s => nousVousStem + s);
        }

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}