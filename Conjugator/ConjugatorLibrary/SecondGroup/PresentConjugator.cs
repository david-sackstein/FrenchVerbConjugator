using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    internal static class PresentConjugator
    {
        private static readonly string[] verbsWithSstEndings =
        {
            "départir", "repartir", "partir", "repentir", "sortir", "consentir", "desservir",
            "dormir", "démentir", "endormir", "mentir", "pressentir", "redormir", "rendormir",
            "ressentir", "resservir", "sentir", "servir"
        };

        private static readonly string[] verbsWithErEndings =
        {
            "accueillir", "assaillir", "couvrir", "cueillir", "découvrir", "défaillir", "entrouvrir",
            "offrir", "ouvrir", "recouvrir", "recueillir", "redécouvrir", "rouvrir", "réouvrir",
            "souffrir", "tressaillir"
        };

        private static readonly string[] verbsWithYonsEndings =
        {
            "choir", "déchoir", "dépourvoir", "entrevoir", "pourvoir", "prévoir", "ravoir", "revoir",
            "voir", "échoir", "enfuir", "fuir"
        };

        private static readonly string[] cevoirVerbs =
        {
            "apercevoir", "concevoir", "décevoir", "entrapercevoir", "percevoir", "recevoir", "préconcevoir"
        };

        private static readonly string[] devoirVerbs =
        {
            "devoir", "redevoir"
        };

        public static string[] GetConjugations(string verb)
        {
            string regularStem = verb.TrimEnd("ir");

            string[] conjugations = IsExplicitIrregular(verb);

            if (conjugations != null)
            {
                return conjugations;
            }

            if (verb.EndsWith("sseoir") || verb.EndsWith("rseoir"))
            {
                string modifiedStem = regularStem.TrimEnd("eo") + "o";
                return AddYonsEndings(modifiedStem);
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

            if (verbsWithYonsEndings.Contains(verb))
            {
                return AddYonsEndings(regularStem);
            }

            if (devoirVerbs.Contains(verb))
            {
                string prefix = verb.TrimEnd("devoir");
                return AddSstEndings(prefix + "doi", prefix + "dev", prefix + "doiv");
            }

            if (cevoirVerbs.Contains(verb))
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

            if (verbsWithSstEndings.Contains(verb))
            {
                string singularStem = regularStem[..^1];
                return AddSstEndings(singularStem, regularStem, regularStem);
            }

            if (verbsWithErEndings.Contains(verb))
            {
                return AddErEndings(regularStem);
            }

            if (verb.EndsWith("valoir"))
            {
                var endings = new[] {"aux", "aux", "aut", "alons", "alez", "alent"};
                return endings.AddEndings(verb.TrimEnd("aloir"));
            }

            return AddRegularEndings(regularStem);
        }

        private static string[] IsExplicitIrregular(string verb)
        {
            return verb switch
            {
                "avoir" => new[] {"ai", "as", "a", "avons", "avez", "ont"},
                "vouloir" => new[] {"veux", "veux", "veut", "voulons", "voulez", "veulent"},
                "pouvoir" => new[] {"peux", "peux", "peut", "pouvons", "pouvez", "peuvent"},
                "faillir" => new[] {"faux", "faux", "faut", "faillons", "faillez", "faillent"},
                "gésir" => new[] {"gis", "gis", "gît", "gisons", "gisez", "gisent"},
                "seoir" => new[] {"", "", "sied", "", "", "siéent"},
                "messeoir" => new[] {"", "", "messied", "", "", "messiéent"},
                "pleuvoir" => new[] {"", "", "pleut", "", "", "pleuvent"},
                "falloir" => new[] {"", "", "faut", "", "", ""},
                "chaloir" => new[] {"", "", "chaut", "", "", ""},
                _ => null
            };
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