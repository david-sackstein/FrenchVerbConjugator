using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class ImperatifConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "savoir")
            {
                return new[] {"", "sache", "" , "sachons", "sachez", ""  };
            }

            if (verb == "faillir")
            {
                return new[] {"", "faille", "" , "faillons", "faillez", ""  };
            }

            if (verb == "avoir")
            {
                return new[] {"", "aie", "" , "ayons", "ayez", ""  };
            }

            string[] present = PresentConjugator.GetConjugations(verb);
            return new[]
            {
                null,
                Exceptions.verbsWithErEndings.Contains(verb) ? present[1].TrimEnd("s") : present[1], // tu
                null,
                present[3], // nous
                present[4], // vous
                null
            };
        }
    }
}