using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifPresentConjugator
    {
        private static readonly string[] Endings = { "e", "es", "e", "ions", "iez", "ent" };

        public static string[] GetConjugations(string verb)
        {
            switch (verb)
            {
                case "avoir":
                    return new[] {"aie", "aies", "ait", "ayons", "ayez", "aient"};
                case "falloir":
                    return new[] { "", "", "faille", "", "", "" };
                case "savoir":
                    return Endings.AddEndings("sach");
                case "pouvoir":
                    return Endings.AddEndings("puiss");
                case "pleuvoir":
                    return Endings.AddEndings("pleuv");
            }

            if (verb.EndsWith("seoir"))
            {
                var stem = verb.TrimEnd("eoir");
                if (verb.EndsWith("asseoir"))
                {
                    return AddEndings(Endings, new ComplexStem(stem + "oi", stem + "oy"));
                }

                return Endings.AddEndings(stem + "ié");
            }

            ComplexStem complexStem = GetComplexStem(verb);
            if (complexStem != null)
            {
                return AddEndings(Endings, complexStem);
            }

            var present = PresentConjugator.GetConjugations(verb);
            var nousForm = present[3];

            var regularStem = nousForm.TrimEnd("ons");
            return Endings.AddEndings(regularStem);
        }

        private static ComplexStem GetComplexStem(string verb)
        {
            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                return new ComplexStem(stem + "ienn", stem + "en");
            }

            if (verb.EndsWith("quérir"))
            {
                var stem = verb.TrimEnd("érir");
                return new ComplexStem(stem + "ièr", stem + "ér");
            }

            if (verb == "vouloir")
            {
                return new ComplexStem("veuill", "voul");
            }

            if (verb.EndsWith("aloir") && verb != "prévaloir")
            {
                var stem = verb.TrimEnd("loir");
                return new ComplexStem(stem + "ill", stem + "l");
            }

            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                var stem = verb.TrimEnd("cevoir");
                return new ComplexStem(stem + "çoiv", stem + "cev");
            }

            if (Exceptions.devoirVerbs.Contains(verb))
            {
                var stem = verb.TrimEnd("devoir");
                return new ComplexStem(stem + "doiv", stem + "dev");
            }

            if (verb.EndsWith("mouvoir"))
            {
                var stem = verb.TrimEnd("mouvoir");
                return new ComplexStem(stem + "meuv", stem + "mouv");
            }

            if (verb == "mourir")
            {
                var stem = verb.TrimEnd("mourir");
                return new ComplexStem(stem + "meur", stem + "mour");
            }

            if (verb.EndsWith("fuir") ||
                verb.EndsWith("choir") ||
                verb.EndsWith("voir"))
            {
                var stem = verb.TrimEnd("ir");
                return new ComplexStem(stem + "i", stem + "y");
            }

            return null;
        }

        private static string[] AddEndings(string[] endings, ComplexStem complexStem)
        {
            return endings.MatchNousVous(
                ending => complexStem.NonNousVousStem + ending, 
                ending => complexStem.NousVousStem + ending);
        }
    }
}