using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class ParticipePasseConjugator
    {
        public static string[] Endings { get; } = {"i", "is", "ie", "ies"};

        public static string[] GetConjugations(string verb)
        {
            if (verb.EndsWith("mourir"))
            {
                Console.WriteLine();
            }
            (bool ok, string[] array) = ExplicitExceptions(verb);
            if (ok)
            {
                return array;
            }

            (bool ok1, string[] conjugations) = WithIsEndings(verb);
            if (ok1)
            {
                return conjugations;
            }

            (bool ok2, string[] strings) = WithErtEndings(verb);
            if (ok2)
            {
                return strings;
            }

            (bool ok3, string[] addEndings1) = AddUEndings(verb);
            if (ok3)
            {
                return addEndings1;
            }

            string stem = GetStem(verb);

            // regular
            return Endings.AddEndings(stem);
        }

        private static (bool, string[]) ExplicitExceptions(string verb)
        {
            if (verb == "avoir")
            {
                return (true, new[] {"eu", "eus", "eue", "eues"});
            }

            if (verb == "pouvoir")
            {
                return (true, Enumerable.Repeat("pu", 4).ToArray());
            }

            if (verb == "pleuvoir")
            {
                return (true, Enumerable.Repeat("plu", 4).ToArray());
            }

            if (verb == "falloir")
            {
                return (true, Enumerable.Repeat("fallu", 4).ToArray());
            }

            if (verb == "mourir")
            {
                return (true, new [] {"mort", "morts", "morte", "mortes" });
            }

            if (verb == "mouvoir")
            {
                // dubious because devoir doesnt work like this
                string[] endings = {"û", "ûs", "ûe", "ûes"};
                return (true, endings.AddEndings("m"));
            }

            return (false, null);
        }

        private static (bool, string[]) AddUEndings(string verb)
        {
            if (verb == "savoir")
            {
                string shortenedStem = verb.TrimEnd("avoir");
                string[] endings = {"u", "us", "ue", "ues"};
                {
                    return (true, endings.AddEndings(shortenedStem));
                }
            }

            if (verb.EndsWith("devoir"))
            {
                string shortenedStem = verb.TrimEnd("evoir");
                string[] endings = { "û", "us", "ue", "ues" };

                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb.EndsWith("ouvoir"))
            {
                string shortenedStem = verb.TrimEnd("ouvoir");
                string[] endings = {"u", "us", "ue", "ues"};
                {
                    return (true, endings.AddEndings(shortenedStem));
                }
            }

            if (verb.EndsWith("cevoir"))
            {
                string shortenedStem = verb.TrimEnd("cevoir") + "ç";
                string[] endings = {"u", "us", "ue", "ues"};

                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb == "dévêtir" || verb == "férir" || verb == "revêtir" || verb == "vêtir" || verb == "issir")
            {
                string[] endings = {"u", "us", "ue", "ues"};
                {
                    string stem = verb.TrimEnd("ir");
                    return (true, endings.AddEndings(stem));
                }
            }

            if (verb.EndsWith("oir"))
            {
                string shortenedStem = verb.TrimEnd("oir");
                string[] endings = {"u", "us", "ue", "ues"};
                {
                    return (true, endings.AddEndings(shortenedStem));
                }
            }

            if (verb.EndsWith("enir") || verb.EndsWith("ourir"))
            {
                string stem = verb.TrimEnd("ir");
                string[] endings = {"u", "us", "ue", "ues"};
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
                {
                    return (true, endings.AddEndings(shortenedStem));
                }
            }

            return (false, null);
        }

        private static (bool, string[]) WithIsEndings(string verb)
        {
            if (verb.EndsWith("eoir"))
            {
                string shortenedStem = verb.TrimEnd("eoir");
                string[] endings = {"is", "is", "ise", "ises"};
                {
                    return (true, endings.AddEndings(shortenedStem));
                }
            }

            if (verb.EndsWith("uérir") && verb != "guérir")
            {
                string[] endings = { "is", "is", "ise", "ises" };
                string shortenedStem = verb.TrimEnd("érir");
                return (true, endings.AddEndings(shortenedStem));
            }

            if (verb == "rassir")
            {
                string stem = verb.TrimEnd("ir");
                string[] endings = {"is", "is", "ise", "ises"};
                return (true, endings.AddEndings(stem));
            }

            return (false, null);
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