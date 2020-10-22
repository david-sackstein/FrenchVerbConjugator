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

            if (verb == "enorgueillir")
            {
                Console.WriteLine();
            }
            var stem = verb[..^2];

            if (stem.EndsWith("en"))
            {
                string modifiedStem = stem[..^2] + "ien";
                var endings = new[] {"s", "s", "t" , "ons" , "ez" , "nent" };
                return endings.AddEndings(modifiedStem, stem);
            }

            if (stem.EndsWith("cour"))
            {
                var endings = new[] { "s", "s", "t", "ons", "ez", "ent" };
                return endings.AddEndings(stem);
            }

            if (stem.EndsWith("cueill"))
            {
                var endings = new[] { "e", "es", "e", "ons", "ez", "ent" };
                return endings.AddEndings(stem);
            }

            if (stem.EndsWith("quér"))
            {
                string modifiedStem = stem[..^2] + "ier";
                string ilsStem = stem[..^2] + "ièr";
                var endings = new[] { "s", "s", "t", "ons", "ez", "ent" };
                var modified = endings.AddEndings(modifiedStem, stem, ilsStem);
                return modified;
            }

            if (stem.EndsWith("cevo"))
            {
                var endings = new[] { "çois", "çois", "çoit", "cevons", "cevez", "çoivent" };
                var modified = endings.AddEndings(stem[..^4]);
                return modified;
            }

            if (stem.EndsWith("vo"))
            {
                var endings = new[] { "is", "is", "it", "yons", "yez", "ient" };
                var modified = endings.AddEndings(stem);
                return modified;
            }
            return Endings.AddEndings(stem);
        }
    }
}