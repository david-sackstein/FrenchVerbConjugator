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

            if (verb == "maintenir")
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
            return Endings.AddEndings(stem);
        }
    }
}