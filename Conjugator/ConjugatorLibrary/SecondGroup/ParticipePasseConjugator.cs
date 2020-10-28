using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class ParticipePasseConjugator
    {
        public static string[] Endings { get; } = {"i", "is", "ie", "ies"};

        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] { "eu",  "eus",  "eue",  "eues"};
            }

            if (verb == "pouvoir")
            {
                return Enumerable.Repeat("pu", 4).ToArray();
            }

            if (verb == "pleuvoir")
            {
                return Enumerable.Repeat("plu", 4).ToArray();
            }

            if (verb == "falloir")
            {
                return Enumerable.Repeat("fallu", 4).ToArray();
            }

            string stem = GetStem(verb);

            if (verb.EndsWith("eoir"))
            {
                string shortenedStem = verb.TrimEnd("eoir");
                string[] endings = { "is", "is", "ise", "ises" };
                return endings.AddEndings(shortenedStem);
            }

            if (verb.EndsWith("ouvrir") || verb == "offrir" || verb == "souffrir")
            {
                string shortenedStem = verb.TrimEnd("rir");
                string[] endings = { "ert", "erts", "erte", "ertes" };
                return endings.AddEndings(shortenedStem);
            }

            if (verb == "savoir")
            {
                string shortenedStem = verb.TrimEnd("avoir");
                string[] endings = { "u", "us", "ue", "ues" };
                return endings.AddEndings(shortenedStem);
            }

            if (verb.EndsWith("devoir"))
            {
                string shortenedStem = verb.TrimEnd("evoir");
                string[] endings = { "û", "us", "ue", "ues" };

                return endings.AddEndings(shortenedStem);
            }

            if (verb.EndsWith("ouvoir"))
            {
                string shortenedStem = verb.TrimEnd("ouvoir");
                string[] endings = { "u", "us", "ue", "ues" };
                return endings.AddEndings(shortenedStem);
            }

            if (verb.EndsWith("cevoir"))
            {
                string shortenedStem = verb.TrimEnd("cevoir") + "ç";
                string[] endings = { "u", "us", "ue", "ues" };

                return endings.AddEndings(shortenedStem);
            }

            if (verb == "dévêtir" || verb == "férir" || verb == "revêtir" || verb == "vêtir" || verb == "issir")
            {
                string[] endings = { "u", "us", "ue", "ues" };
                return endings.AddEndings(stem);
            }

            if (verb.EndsWith("uérir") && verb != "guérir")
            {
                string shortenedStem = verb.TrimEnd("érir");
                string[] endings = { "is", "is", "ise", "ises" };
                return endings.AddEndings(shortenedStem);
            }

            if (verb == "rassir")
            {
                string[] endings = { "is", "is", "ise", "ises" };
                return endings.AddEndings(stem);
            }

            if (verb.EndsWith("oir"))
            {
                string shortenedStem = verb.TrimEnd("oir");
                string[] endings = { "u", "us", "ue", "ues" };
                return endings.AddEndings(shortenedStem);
            }

            if (verb.EndsWith("enir") || verb.EndsWith("ourir"))
            {
                string[] endings = {"u", "us", "ue", "ues"};
                return endings.AddEndings(stem);
            }

            return Endings.AddEndings(stem);
        }

        private static string GetStem(string verb)
        {
            if (verb == "aller")
            {
                return "all";
            }

            return verb.Remove(verb.Length - 2);
        }
    }
}