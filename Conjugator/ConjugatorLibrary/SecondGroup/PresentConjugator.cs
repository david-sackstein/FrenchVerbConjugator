using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    internal static class PresentConjugator
    {
        private static readonly string[] verbsWithErEndings =
        {
            "départir", "repartir", "partir", "repentir", "sortir", "consentir", "desservir",
            "dormir", "démentir", "endormir", "mentir", "pressentir", "redormir", "rendormir",
            "ressentir", "resservir", "sentir", "servir"
        };

        private static readonly string[] verbsWithYonsEndings =
        {
            "choir", "déchoir", "dépourvoir", "entrevoir", "pourvoir", "prévoir", "ravoir", "revoir",
            "voir", "échoir", "enfuir", "fuir"
        };

        public static string[] GetConjugations(string verb)
        {
            string[] conjugations = Irregular(verb);
            if (conjugations != null)
            {
                return conjugations;
            }

            if (verb.EndsWith("mouvoir"))
            {
                var endings = new[] { "meus", "meus", "meut", "mouvons", "mouvez", "meuvent" };
                return endings.AddEndings(verb.TrimEnd("mouvoir"));
            }

            if (verb.EndsWith("mourir"))
            {
                var endings = new[] { "meurs", "meurs", "meurt", "mourons", "mourez", "meurent" };
                return endings.AddEndings(verb.TrimEnd("mourir"));
            }

            if (verb == "savoir")
            {
                return AddSstEndings("sai", "sav", "sav");
            }

            string regularStem = verb.TrimEnd("ir");

            if (verb.EndsWith("sseoir") || verb.EndsWith("rseoir"))
            {
                string modifiedStem = regularStem.TrimEnd("eo") + "o";
                return AddYonsEndings(modifiedStem);
            }

            if (verbsWithYonsEndings.Contains(verb))
            {
                return AddYonsEndings(regularStem);
            }

            if (verb.IsOneOf("devoir", "redevoir"))
            {
                string prefix = verb.TrimEnd("devoir");
                return AddSstEndings(prefix + "doi", prefix + "dev", prefix + "doiv");
            }

            if (verb.IsOneOf("apercevoir", "concevoir", "décevoir", "entrapercevoir", "percevoir", "recevoir",
                "préconcevoir"))
            {
                string prefix = verb.TrimEnd("cevoir");
                return AddSstEndings(prefix + "çoi", prefix + "cev", prefix + "çoiv");
            }

            if (verb.EndsWith("enir"))
            {
                string modifiedStem = regularStem.ReplaceEnd("en", "ien");
                return AddSstEndings(modifiedStem, regularStem, modifiedStem + 'n');
            }

            if (verb.EndsWith("bouillir"))
            {
                string singularStem = regularStem.TrimEnd("ill");
                return AddSstEndings(singularStem, regularStem, regularStem);
            }

            if (verb.EndsWith("vêtir"))
            {
                return AddSstEndings(regularStem);
            }

            if (verb.EndsWith("quérir"))
            {
                string singularStem = regularStem.TrimEnd("ér") + "ier";
                string ilsStem = regularStem.TrimEnd("ér") + "ièr";

                return AddSstEndings(singularStem, regularStem, ilsStem);
            }

            if (verb.EndsWith("courir"))
            {
                return AddSstEndings(regularStem);
            }

            if (verbsWithErEndings.Contains(verb))
            {
                string singularStem = regularStem[..^1];
                return AddSstEndings(singularStem, regularStem, regularStem);
            }

            if (verb.EndsWith("valoir"))
            {
                var endings = new[] {"aux", "aux", "aut", "alons", "alez", "alent"};
                return endings.AddEndings(verb.TrimEnd("aloir"));
            }

            if (verb.IsOneOf("accueillir", "assaillir", "couvrir", "cueillir", "découvrir", "défaillir", "entrouvrir",
                "offrir", "ouvrir", "recouvrir", "recueillir", "redécouvrir", "rouvrir", "réouvrir",
                "souffrir", "tressaillir"))
            {
                return AddErEndings(regularStem);
            }

            return AddRegularEndings(regularStem);
        }

        private static string[] Irregular(string verb)
        {
            switch (verb)
            {
                case "avoir":
                    return new[] {"ai", "as", "a", "avons", "avez", "ont"};
                case "vouloir":
                    return new[] {"veux", "veux", "veut", "voulons", "voulez", "veulent"};
                case "pouvoir":
                    return new[] {"peux", "peux", "peut", "pouvons", "pouvez", "peuvent"};
                case "faillir":
                    return new[] {"faux", "faux", "faut", "faillons", "faillez", "faillent"};
                case "gésir":
                    return new[] {"gis", "gis", "gît", "gisons", "gisez", "gisent"};
                case "seoir":
                case "messeoir":
                    string modifiedStem = verb.TrimEnd("seoir");
                    return new[] {"", "", modifiedStem + "sied", "", "", modifiedStem + "siéent"};
                case "pleuvoir":
                    return new[] { "", "", "pleut", "", "", "pleuvent" };
                case "falloir":
                    return new[] { "", "", "faut", "", "", "" };
                case "chaloir":
                    return new[] { "", "", "chaut", "", "", "" };
            }

            return null;
        }

        private static string[] AddErEndings(string regularStem)
        {
            var endings = new[] {"e", "es", "e", "ons", "ez", "ent"};
            return endings.AddEndings(regularStem);
        }

        private static string[] AddSstEndings(string singularStem, string nousVousStem, string ilsStem)
        {
            var endings = new[] {"s", "s", "t", "ons", "ez", "ent"};
            return endings.AddEndings(singularStem, nousVousStem, ilsStem);
        }

        private static string[] AddSstEndings(string stem)
        {
            string ilEnding = stem[^1] == 't' ? "" : "t";
            string[] endings = {"s", "s", ilEnding, "ons", "ez", "ent"};
            return endings.AddEndings(stem);
        }

        private static string[] AddRegularEndings(string stem)
        {
            var endings = new[] {"is", "is", "it", "issons", "issez", "issent"};
            return endings.AddEndings(stem);
        }

        private static string[] AddYonsEndings(string stem)
        {
            var endings = new[] {"is", "is", "it", "yons", "yez", "ient"};
            return endings.AddEndings(stem);
        }
    }
}