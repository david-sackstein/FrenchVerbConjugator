using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    internal static class PresentConjugator
    {
        private static readonly string[] Endings = {"is", "is", "it", "issons", "issez", "issent"};

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

            if (verb == "faillir")
            {
                return new[] { "faux", "faux", "faut", "faillons", "faillez", "faillent" };
            }

            if (verb == "savoir")
            {
                return new[] { "sais", "sais", "sait", "savons", "savez", "savent" };
            }

            string stem = verb.TrimEnd("ir");

            if (verb.EndsWith("mourir"))
            {
                var endings = new[] { "meurs", "meurs", "meurt", "mourons", "mourez", "meurent" };
                return endings.AddEndings(verb.TrimEnd("mourir"));
            }

            if (verb.EndsWith("fuir"))
            {
                var endings = new[] { "fuis", "fuis", "fuit", "fuyons", "fuyez", "fuient" };
                return endings.AddEndings(verb.TrimEnd("fuir"));
            }

            if (verb.EndsWith("eoir"))
            {
                var endings = new[] { "ois", "ois", "oit", "oyons", "oyez", "oient" };
                return endings.AddEndings(verb.TrimEnd("eoir"));
            }
            
            if (verb.EndsWith("mouvoir"))
            {
                var endings = new[] { "meus", "meus", "meut", "mouvons", "mouvez", "meuvent" };
                return endings.AddEndings(verb.TrimEnd("mouvoir"));
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

            if (verb.EndsWith("courir"))
            {
                var endings = new[] {"s", "s", "t", "ons", "ez", "ent"};
                return endings.AddEndings(stem);
            }

            if (verb.EndsWith("cueillir") || verb.EndsWith("ffrir"))
            {
                var endings = new[] {"e", "es", "e", "ons", "ez", "ent"};
                return endings.AddEndings(stem);
            }

            if (verb.EndsWith("quérir"))
            {
                string modifiedStem = stem.TrimEnd("ér") + "ier";
                string ilsStem = stem.TrimEnd("ér") + "ièr";
                var endings = new[] {"s", "s", "t", "ons", "ez", "ent"};
                string[] modified = endings.AddEndings(modifiedStem, stem, ilsStem);
                return modified;
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

            // if (verb != "saillir") is the ons form irregular? ressortir is also a mahloket
            // revêtir is tough

            if (verb.EndsWith("aillir") && !verb.EndsWith("jaillir") || verb.EndsWith("ouvrir"))
            {
                var endings = new[] { "e", "es", "e", "ons", "ez", "ent" };
                string[] modified = endings.AddEndings(stem);
                return modified;
            }

            if (verb.EndsWithAnyOf("dormir", "mentir", "ervir", "sentir") || 
                verb.IsOneOf("départir", "repartir", "partir", "repentir", "sortir") )
            {
                if (! verb.IsOneOf("asservir", "réasservir"))
                {
                    var lastLetter = stem[^1];
                    var endings = new[] {"s", "s", "t", lastLetter + "ons", lastLetter + "ez", lastLetter + "ent" };
                    string[] modified = endings.AddEndings(verb.TrimEnd(lastLetter + "ir"));
                    return modified;
                }
            }

            if (verb.IsOneOf("ressortir"))
            {
                var endings = new[] { "is", "is", "it", "ons", "issez", "issent" };
                string[] modified = endings.AddEndings(stem);
                return modified;
            }

            return Endings.AddEndings(stem);
        }
    }
}