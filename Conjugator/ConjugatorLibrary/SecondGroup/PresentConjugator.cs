using System.Data;

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
                return new[] {"veux", "veux", "veut", "voulons", "voulez", "veulent"};
            }
            
            if (verb == "pouvoir")
            {
                return new[] {"peux", "peux", "peut", "pouvons", "pouvez", "peuvent"};
            }

            if (verb == "faillir")
            {
                return new[] { "faux", "faux", "faut", "faillons", "faillez", "faillent" };
            }

            if (verb == "pleuvoir")
            {
                return new[] {"", "", "pleut", "", "", "pleuvent"};
            }
            
            if (verb == "falloir")
            {
                return new[] {"", "", "faut", "", "", ""};
            }
            
            if (verb == "chaloir")
            {
                return new[] {"", "", "chaut", "", "", ""};
            }
            
            if (verb == "savoir")
            {
                return AddSstEndings("sai", "sav", "sav");
            }
            
            if (verb == "gésir")
            {
                return new[] {"gis", "gis", "gît", "gisons", "gisez", "gisent"};
            }

            if (verb == "seoir" || verb == "messeoir")
            {
                var modifiedStem = verb.TrimEnd("seoir");
                return new[] {"", "", modifiedStem + "sied", "", "", modifiedStem + "siéent"};
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

            string regularStem = verb.TrimEnd("ir");

            if (verb.EndsWith("sseoir") || verb.EndsWith("rseoir"))
            {
                string modifiedStem = regularStem.TrimEnd("eo") + "o";
                return AddYonsEndings(modifiedStem);
            }

            if (verb.EndsWith("fuir"))
            {
                return AddYonsEndings(regularStem);
            }

            if (verb.EndsWith("devoir"))
            {
                string prefix = verb.TrimEnd("devoir");
                return AddSstEndings(prefix + "doi", prefix + "dev", prefix + "doiv");
            }

            if (verb.EndsWith("cevoir"))
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
                var singularStem = regularStem.TrimEnd("ill");
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

            if (verb.EndsWithAnyOf("dormir", "mentir", "ervir", "sentir") ||
                verb.IsOneOf("départir", "repartir", "partir", "repentir", "sortir"))
            {
                if (!verb.IsOneOf("asservir", "réasservir")) // these two are regular
                {
                    var singularStem = regularStem[..^1];
                    return AddSstEndings(singularStem, regularStem, regularStem);
                }
            }

            if (verb.EndsWith("voir") || verb.EndsWith("choir"))
            {
                var endings = new[] {"is", "is", "it", "yons", "yez", "ient"};
                string[] modified = endings.AddEndings(regularStem);
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
                    string[] modified = endings.AddEndings(regularStem);
                    return modified;
                }
            }

            return AddRegularEndings(regularStem);
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