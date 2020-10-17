using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ConjugatorLibrary
{
    public class Conjugator
    {
        public string[] GetErPresent(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));
            Contract.Requires(verb.Length > 2);

            if (verb == "aller")
            {
                return new[] {"vais", "vas", "va", "allons", "allez", "vont"};
            }

            // soften the g before an 'o'
            string onsEnding = "ons";
            if (verb[^3] == 'g')
            {
                onsEnding = "e" + onsEnding;
            }

            string[] endings = {"e", "es", "e", onsEnding, "ez", "ent"};
            string[] withEndings = ApplyEndings(endings, verb);

            // soften the c with a cedilla before an 'o'
            if (verb[^3] == 'c')
            {
                withEndings[3] = ReplaceAt(withEndings[3], -4, 'ç');
            }

            return withEndings;
        }

        private static string[] ApplyEndings(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            if (GetActualStem(stem, out string actualStem))
            {
                return AddEndings(endings, actualStem, stem);
            }
            return endings.Select(ending => stem + ending).ToArray();
        }

        private static bool GetActualStem(string stem, out string actualStem)
        {
            if (stem.Length > 2)
            {
               string stemEnding = stem.Substring(stem.Length - 2);

               if (GetActualStem1(stem, stemEnding, out actualStem))
               {
                   return true;
               }
            }

            if (stem.Length > 3)
            {
                string stemEnding = stem.Substring(stem.Length - 3);

                if (GetActualStem2(stem, stemEnding, out actualStem))
                {
                    return true;
                }
            }

            if (stem.Length > 4)
            {
                string stemEnding = stem.Substring(stem.Length - 4);

                if (GetActualStem3(stem, stemEnding, out actualStem))
                {
                    return true;
                }
            }

            actualStem = "";
            return false;
        }

        private static bool GetActualStem1(string stem, string stemEnding, out string actualStem)
        {
            switch (stemEnding)
            {
                case "oy":
                case "uy":
                {
                    actualStem = ReplaceAt(stem, stem.Length - 1, 'i');
                    return true;
                }

                case "éc":
                case "éd":
                case "ég":
                case "éj":
                case "él":
                case "ém":
                case "én":
                case "ép":
                case "ér":
                case "és":
                case "ét":
                case "es":
                case "em":
                case "ep":
                case "er":
                case "ec":
                case "en":
                case "ev":

                case "el" when Exceptions.noDoubleL.Contains(stem + "er"):
                case "et" when Exceptions.noDoubleT.Contains(stem + "er"):

                    actualStem = ActualStemGrave(stem, stemEnding);
                    return true;

                case "el":
                case "et":

                    actualStem = ActualStemDoubled(stem);
                    return true;
            }

            actualStem = "";
            return false;
        }

        private static bool GetActualStem2(string stem, string stemEnding, out string actualStem)
        {
            switch (stemEnding)
            {
                case "éch":
                case "égu":
                case "ébr":
                case "égl":
                case "évr":
                case "étr":
                case "équ":
                case "égr":
                case "égn":
                case "écr":
                case "evr":
                    actualStem = ActualStemGrave(stem, stemEnding);
                    return true;
            }

            actualStem = "";
            return false;
        }

        private static bool GetActualStem3(string stem, string stemEnding, out string actualStem)
        {
            if (stemEnding == "mour")
            {
                actualStem = ReplaceAt(stem, stem.Length - 3, 'e');
                return true;
            }

            actualStem = "";
            return false;
        }

        private static string ActualStemGrave(string stem, string stemEnding)
        {
            int index = stem.Length - stemEnding.Length;
            string actualStem = ReplaceAt(stem, index, 'è');
            return actualStem;
        }

        private static string ActualStemDoubled(string stem)
        {
            string actualStem = stem + stem[^1];
            return actualStem;
        }

        private static string[] AddEndings(string[] endings, string baseStem, string nousVousStem)
        {
            return new[]
            {
                baseStem + endings[0],
                baseStem + endings[1],
                baseStem + endings[2],
                nousVousStem + endings[3],
                nousVousStem + endings[4],
                baseStem + endings[5],
            };
        }

        private static string ReplaceAt(string inString, int index, char c)
        {
            int actualIndex = index > 0 ? index : inString.Length + index;
            return new StringBuilder(inString) {[actualIndex] = c}.ToString();
        }
    }
}