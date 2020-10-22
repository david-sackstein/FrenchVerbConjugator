using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    internal static class PresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] {"ai", "as", "a", "avons", "avez", "ont"};
            }

            if (verb == "vouloir")
            {
                return new[] { "veux", "veux", "veut", "voulons", "voulez", "veulent" };
            }

            if (verb == "pouvoir")
            {
                return new[] { "peux", "peux", "peut", "pouvons", "pouvez", "peuvent" };
            }

            if (verb == "pleuvoir")
            {
                return new[] { "", "", "pleut", "", "", "pleuvent" };
            }

            if (verb == "falloir")
            {
                return new[] { "", "", "faut", "", "", "" };
            }

            if (verb == "chaloir")
            {
                return new[] { "", "", "chaut", "", "", "" };
            }

            if (verb == "faillir")
            {
                return new[] { "faux", "faux", "faut", "faillons", "faillez", "faillent" };
            }

            if (verb == "savoir")
            {
                return new[] { "sais", "sais", "sait", "savons", "savez", "savent" };
            }

            if (verb == "gésir")
            {
                return new[] { "gis", "gis", "gît", "gisons", "gisez", "gisent" };
            }

            if (verb == "seoir" || verb == "messeoir")
            {
                var modifiedStem = verb.TrimEnd("seoir");
                return new[] { "", "", modifiedStem + "sied", "", "", modifiedStem + "siéent" };
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

            string stem = verb.TrimEnd("ir");

            if (verb.EndsWith("sseoir") || verb.EndsWith("rseoir"))
            {
                string modifiedStem = stem.TrimEnd("eo") + "o";
                return AddYonsEndings(modifiedStem);
            }

            if (verb.EndsWith("fuir"))
            {
                return AddYonsEndings(stem);
            }

            if (verb.EndsWith("devoir"))
            {
                var endings = new[] { "dois", "dois", "doit", "devons", "devez", "doivent" };
                return endings.AddEndings(verb.TrimEnd("devoir"));
            }

            if (verb.EndsWith("enir"))
            {
                string modifiedStem = stem.ReplaceEnd("en", "ien");
                var endings = new[] {"s", "s", "t", "ons", "ez", "nent"};
                return endings.AddEndings(modifiedStem, stem);
            }

            if (verb.EndsWith("bouillir"))
            {
                var endings = new[] { "bous", "bous", "bout", "bouillons", "bouillez", "bouillent" };
                return endings.AddEndings(verb.TrimEnd("bouillir"));
            }

            if (verb.EndsWith("vêtir"))
            {
                return AddSstEndings(stem);
            }

            if (verb.EndsWith("quérir"))
            {
                string singularStem = stem.TrimEnd("ér") + "ier";
                string ilsStem = stem.TrimEnd("ér") + "ièr";
                
                return AddSstEndings(singularStem, stem, ilsStem);
            }

            if (verb.EndsWith("courir"))
            {
                return AddSstEndings(stem);
            }

            if (verb.EndsWithAnyOf("dormir", "mentir", "ervir", "sentir") ||
                verb.IsOneOf("départir", "repartir", "partir", "repentir", "sortir"))
            {
                if (!verb.IsOneOf("asservir", "réasservir")) // these two are regular
                {
                    var lastLetter = stem[^1];
                    var endings = new[] { "s", "s", "t", lastLetter + "ons", lastLetter + "ez", lastLetter + "ent" };
                    return endings.AddEndings(verb.TrimEnd(lastLetter + "ir"));
                }
            }

            if (verb.EndsWith("cevoir"))
            {
                var endings = new[] {"çois", "çois", "çoit", "cevons", "cevez", "çoivent"};
                string[] modified = endings.AddEndings(verb.TrimEnd("cevoir"));
                return modified;
            }

            if (verb.EndsWith("voir") || verb.EndsWith("choir"))
            {
                var endings = new[] {"is", "is", "it", "yons", "yez", "ient"};
                string[] modified = endings.AddEndings(stem);
                return modified;
            }

            if (verb.EndsWith("valoir"))
            {
                var endings = new[] {"aux", "aux", "aut", "alons", "alez", "alent"};
                string[] modified = endings.AddEndings(verb.TrimEnd("aloir"));
                return modified;
            }

            if (verb.EndsWith("cueillir") 
                || verb.EndsWith("ffrir") 
                || verb.EndsWith("aillir") 
                || verb.EndsWith("ouvrir"))
            {
                if (!verb.EndsWith("jaillir") && verb != "saillir")
                {
                    var endings = new[] {"e", "es", "e", "ons", "ez", "ent"};
                    string[] modified = endings.AddEndings(stem);
                    return modified;
                }
            }

            return AddRegularEndings(stem);
        }

        private static string[] AddSstEndings(string singularStem, string nousVousStem, string ilsStem)
        {
            var endings = new[] {"s", "s", "t", "ons", "ez", "ent"};
            return endings.AddEndings(singularStem, nousVousStem, ilsStem);
        }

        private static string[] AddSstEndings(string stem)
        {
            var il = stem[^1] == 't' ? "" : "t";
            var endings = new[] {"s", "s", il, "ons", "ez", "ent"};
            return endings.AddEndings(stem);
        }

        private static string[] AddRegularEndings(string stem)
        {
            var endings = new[] { "is", "is", "it", "issons", "issez", "issent" };
            return endings.AddEndings(stem);
        }

        private static string[] AddYonsEndings(string stem)
        {
            var endings = new[] {"is", "is", "it", "yons", "yez", "ient"};
            return endings.AddEndings(stem);
        }
    }
}