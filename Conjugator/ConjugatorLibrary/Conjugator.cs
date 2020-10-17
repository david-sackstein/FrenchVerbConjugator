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

            if (stem.Length > 2)
            {
                if (Strings(endings, verb, stem, out string actualStem))
                {
                    return AddEndings(endings, actualStem, stem);
                }
            }

            if (stem.Length > 3)
            {
                string stemEnding = stem.Substring(stem.Length - 3);

                switch (stemEnding)
                {
                    case "éch": case "égu": case "ébr": case "égl": case "évr":
                    case "étr": case "équ": case "égr": case "égn": case "écr":
                    case "evr":
                        string actualStem = ActualStemGrave(stem, stemEnding);
                        return AddEndings(endings, actualStem, stem);
                }
            }

            if (stem.Length > 4)
            {
                string stemEnding = stem.Substring(stem.Length - 4);

                if (stemEnding == "mour")
                {
                    string stemJeTuIlIls = ReplaceAt(stem, stem.Length - 3, 'e');
                    return AddEndings(endings, stemJeTuIlIls, stem);
                }
            }

            return endings.Select(ending => stem + ending).ToArray();
        }

        private static bool Strings(string[] endings, string verb, string stem, out string actualStem5)
        {
            string stemEnding = stem.Substring(stem.Length - 2);

            switch (stemEnding)
            {
                case "oy":
                case "uy":
                {
                    actualStem5 = ReplaceAt(stem, stem.Length - 1, 'i');
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

                case "el" when Exceptions.noDoubleL.Contains(verb):
                case "et" when Exceptions.noDoubleT.Contains(verb):

                    actualStem5 = ActualStemGrave(stem, stemEnding);
                    return true;

                case "el":
                case "et":

                    actualStem5 = ActualStemDoubled(stem);
                    return true;
            }

            actualStem5 = "";
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