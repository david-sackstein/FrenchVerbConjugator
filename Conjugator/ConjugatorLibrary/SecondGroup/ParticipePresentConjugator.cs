using System;

namespace ConjugatorLibrary.SecondGroup
{
    public static class ParticipePresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] {"ayant"};
            }

            if (verb == "savoir")
            {
                return new[] {"sachant"};
            }

            if (verb == "pleuvoir")
            {
                return new[] {"pleuvant"};
            }

            if (verb.EndsWith("seoir"))
            {
                if (verb.EndsWith("asseoir"))
                {
                    return new[] {verb.TrimEnd("seoir") + "soyant"};
                }

                return new[] {verb.TrimEnd("seoir") + "séant"};
            }

            string conjugation = PresentConjugator.GetConjugations(verb)[3];
            if (string.IsNullOrEmpty(conjugation))
            {
                return null;
            }
            string stem = conjugation.TrimEnd("ons");
            return new[] { stem + "ant" };
        }

        private static string GetStem(string verb)
        {
            string stem = PresentConjugator.GetConjugations(verb)[3].TrimEnd("ons");
            return stem;
        }
    }
}