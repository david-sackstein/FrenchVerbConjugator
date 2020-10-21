using System;

namespace ConjugatorLibrary.SecondGroup
{
    static class PresentConjugator
    {
        private static readonly string[] Endings = {"is", "is" , "it", "issons", "issez", "issent" };

        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] {"ai", "as", "a", "avons", "avez", "ont"};
            }

            var stem = verb[..^2];

            if (verb.EndsWith("enir"))
            {
                string modifiedStem = stem[..^2] + "ien";
                var endings = new[] {"s", "s", "t" , "ons" , "ez" , "nent" };
                return endings.AddEndings(modifiedStem, stem);
            }

            if (verb.EndsWith("courir"))
            {
                var endings = new[] { "s", "s", "t", "ons", "ez", "ent" };
                return endings.AddEndings(stem);
            }

            if (verb.EndsWith("cueillir"))
            {
                var endings = new[] { "e", "es", "e", "ons", "ez", "ent" };
                return endings.AddEndings(stem);
            }

            if (verb.EndsWith("quérir"))
            {
                string modifiedStem = stem[..^2] + "ier";
                string ilsStem = stem[..^2] + "ièr";
                var endings = new[] { "s", "s", "t", "ons", "ez", "ent" };
                var modified = endings.AddEndings(modifiedStem, stem, ilsStem);
                return modified;
            }

            if (verb.EndsWith("cevoir"))
            {
                var endings = new[] { "çois", "çois", "çoit", "cevons", "cevez", "çoivent" };
                var modified = endings.AddEndings(stem[..^4]);
                return modified;
            }

            if (verb.EndsWith("voir") || verb.EndsWith("choir"))
            {
                var endings = new[] { "is", "is", "it", "yons", "yez", "ient" };
                var modified = endings.AddEndings(stem);
                return modified;
            }

            if (verb.EndsWith("valoir"))
            {
                var endings = new[] { "aux", "aux", "aut", "alons", "alez", "alent" };
                var modified = endings.AddEndings(stem[..^3]);
                return modified;
            }

            if (verb.EndsWith("aillir") && !verb.EndsWith("jaillir"))
            {
                var endings = new[] { "e", "es", "e", "ons", "ez", "ent" };
                var modified = endings.AddEndings(stem);
                return modified;
            }

            return Endings.AddEndings(stem);
        }
    }
}