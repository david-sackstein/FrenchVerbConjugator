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
            var present = PresentConjugator.GetConjugations(verb);
            var nousForm = present[3];

            if (verb == "savoir")
            {
                return new[] {"sache", "saches", "sache", "sachions", "sachiez", "sachent"};
            }

            if (verb == "falloir")
            {
                return new[] {"", "", "faille", "", "", ""};
            }

            if (verb == "pouvoir")
            {
                var stem = "puiss";
                return AddEndings(endings, stem);
            }

            if (verb == "pleuvoir")
            {
                var stem = verb.TrimEnd("oir");
                return AddEndings(endings, stem);
            }

            if (verb.EndsWith("seoir"))
            {
                var stem = verb.TrimEnd("eoir");
                if (verb.EndsWith("asseoir"))
                {
                    var nousVousStem = stem + "oy";
                    var nonNousVousStem = stem + "oi";
                    return AddEndings(endings, nonNousVousStem, nousVousStem);
                }

                var modifiedStem = stem + "ié";
                return AddEndings(endings, modifiedStem);
            }

            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                var nousVousStem = stem + "en";
                var nonNousVousStem = stem + "ienn";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb.EndsWith("quérir"))
            {
                var stem = verb.TrimEnd("érir");
                var nousVousStem = stem + "ér";
                var nonNousVousStem = stem + "ièr";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb == "vouloir")
            {
                var nousVousStem = "voul";
                var nonNousVousStem = "veuill";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb.EndsWith("cevoir"))
            {
                var stem = verb.TrimEnd("cevoir");
                var nousVousStem = stem + "cev";
                var nonNousVousStem = stem + "çoiv";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb.EndsWith("devoir"))
            {
                var stem = verb.TrimEnd("devoir");
                var nousVousStem = stem + "dev";
                var nonNousVousStem = stem + "doiv";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb.EndsWith("mouvoir"))
            {
                var stem = verb.TrimEnd("mouvoir");
                var nousVousStem = stem + "mouv";
                var nonNousVousStem = stem + "meuv";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb == "mourir")
            {
                var stem = verb.TrimEnd("mourir");
                var nousVousStem = "mour";
                var nonNousVousStem = "meur";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb.EndsWith("fuir") ||
                verb.EndsWith("choir") ||
                verb.EndsWith("voir"))
            {
                var stem = verb.TrimEnd("ir");
                var nousVousStem = stem + "y";
                var nonNousVousStem = stem + "i";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            if (verb.EndsWith("aloir") && verb != "prévaloir")
            {
                var stem = verb.TrimEnd("loir");
                var nousVousStem = stem + "l";
                var nonNousVousStem = stem + "ill";
                return AddEndings(endings, nonNousVousStem, nousVousStem);
            }

            var regularStem = nousForm.TrimEnd("ons");
            return AddEndings(endings, regularStem);
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