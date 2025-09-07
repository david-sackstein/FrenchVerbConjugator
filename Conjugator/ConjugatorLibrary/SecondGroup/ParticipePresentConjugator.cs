using System;

namespace ConjugatorLibrary.SecondGroup
{
    public static class ParticipePresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return ["ayant"];
            }

            if (verb == "savoir")
            {
                return ["sachant"];
            }

            if (verb == "pleuvoir")
            {
                return ["pleuvant"];
            }

            if (verb.EndsWith("seoir"))
            {
                if (verb.EndsWith("asseoir"))
                {
                    return [verb.TrimEnd("seoir") + "soyant"];
                }

                return [verb.TrimEnd("seoir") + "séant"];
            }

            string conjugation = PresentConjugator.GetConjugations(verb)[3];
            if (string.IsNullOrEmpty(conjugation))
            {
                return null;
            }
            string stem = conjugation.TrimEnd("ons");
            return [stem + "ant"];
        }

        private static string GetStem(string verb)
        {
            string stem = PresentConjugator.GetConjugations(verb)[3].TrimEnd("ons");
            return stem;
        }
    }
}