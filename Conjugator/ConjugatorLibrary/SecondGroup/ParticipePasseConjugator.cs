using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class ParticipePasseConjugator
    {
        public static string[] Endings { get; } = {"i", "is", "ie", "ies"};

        public static string[] GetConjugations(string verb)
        {
            Func<string, (bool, string[])>[] exceptionHandlers = {
                ExplicitExceptions, 
                WithIsEndings, 
                WithErtEndings, 
                AddUEndings
            };

            foreach (var exceptionHandler in exceptionHandlers)
            {
                (bool isHandled, string[] conjugations) = exceptionHandler(verb);
                if (isHandled)
                {
                    return conjugations;
                }
            }

            string stem = GetStem(verb);

            // regular
            return Endings.AddEndings(stem);
        }

        private static (bool, string[]) ExplicitExceptions(string verb)
        {
            return verb switch
            {
                "avoir" => (true, new[] {"eu", "eus", "eue", "eues"}),
                "pouvoir" => (true, Enumerable.Repeat("pu", 4).ToArray()),
                "pleuvoir" => (true, Enumerable.Repeat("plu", 4).ToArray()),
                "falloir" => (true, Enumerable.Repeat("fallu", 4).ToArray()),
                "mourir" => (true, new[] {"mort", "morts", "morte", "mortes"}),
                "mouvoir" => (true, new[] {"mû", "mûs", "mûe", "mûes"}), // dubious because devoir doesnt work like this
                _ => (false, null)
            };
        }

        private static (bool, string[]) AddUEndings(string verb)
        {
            string[] endings = { "u", "us", "ue", "ues" };

            if (verb == "savoir")
            {
                string shortenedStem = verb.TrimEnd("avoir");
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb.EndsWith("devoir"))
            {
                string shortenedStem = verb.TrimEnd("evoir");
                string[] endings1 = { "û", "us", "ue", "ues" };
                return (true, endings1.AddEndings(shortenedStem));
            }

            if (verb.EndsWith("ouvoir"))
            {
                string shortenedStem = verb.TrimEnd("ouvoir");
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb.EndsWith("cevoir"))
            {
                string shortenedStem = verb.TrimEnd("cevoir") + "ç";
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb == "dévêtir" || verb == "férir" || verb == "revêtir" || verb == "vêtir" || verb == "issir")
            {
                string stem = verb.TrimEnd("ir");
                return (true, endings.AddEndings(stem));
            }

            if (verb.EndsWith("oir"))
            {
                string shortenedStem = verb.TrimEnd("oir");
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb.EndsWith("enir") || verb.EndsWith("ourir"))
            {
                string stem = verb.TrimEnd("ir");
                return (true, endings.AddEndings(stem));
            }

            return (false, null);
        }

        private static (bool, string[]) WithErtEndings(string verb)
        {
            if (verb.EndsWith("ouvrir") || verb == "offrir" || verb == "souffrir")
            {
                string shortenedStem = verb.TrimEnd("rir");
                string[] endings = {"ert", "erts", "erte", "ertes"};
                return (true, endings.AddEndings(shortenedStem));
            }

            return (false, null);
        }

        private static (bool, string[]) WithIsEndings(string verb)
        {
            string[] endings = { "is", "is", "ise", "ises" };
            if (verb.EndsWith("eoir"))
            {
                string shortenedStem = verb.TrimEnd("eoir");
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb.EndsWith("uérir") && verb != "guérir")
            {
                string shortenedStem = verb.TrimEnd("érir");
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb == "rassir")
            {
                string stem = verb.TrimEnd("ir");
                return (true, endings.AddEndings(stem));
            }

            return (false, null);
        }

        private static string GetStem(string verb)
        {
            return verb.Remove(verb.Length - 2);
        }
    }
}