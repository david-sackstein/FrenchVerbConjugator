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

            string stem = verb[..^2];

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

            if (verb.EndsWith("cueillir"))
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

            if (verb.EndsWith("aillir") && !verb.EndsWith("jaillir") || verb.EndsWith("ouvrir"))
            {
                var endings = new[] {"e", "es", "e", "ons", "ez", "ent"};
                string[] modified = endings.AddEndings(stem);
                return modified;
            }

            if (verb.EndsWithAnyOf("dormir", "mentir", "ervir", "sentir") && 
                ! verb.IsOneOf("asservir", "réasservir"))
            {
                var lastLetter = stem[^1];
                var endings = new[] {"s", "s", "t", lastLetter + "ons", lastLetter + "ez", lastLetter + "ent" };
                string[] modified = endings.AddEndings(verb.TrimEnd(lastLetter + "ir"));
                return modified;
            }

            return Endings.AddEndings(stem);
        }
    }
}