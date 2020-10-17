using System.Linq;

namespace ConjugatorLibrary
{
    public static class StemConverter
    {
        // The base stem is used for je, tu, il, ils but not for nous and vous
        public static bool GetBaseStem(string stem, out string baseStem)
        {
            if (
                GetBaseStem2(stem, out baseStem) || 
                GetBaseStem3(stem, out baseStem) || 
                GetBaseStem4(stem, out baseStem))
            {
                return true;
            }

            baseStem = "";
            return false;
        }

        private static bool GetBaseStem2(string stem, out string actualStem)
        {
            const int endingLength = 2;

            if (stem.Length < endingLength)
            {
                goto NoChange;
            }

            // @formatter:off

            string stemEnding = stem.Substring(stem.Length - endingLength);
            switch (stemEnding)
            {
                case "oy":
                case "uy":
                {
                    actualStem = stem.ReplaceAt(stem.Length - 1, 'i');
                    return true;
                }

                case "éc": case "éd": case "ég": case "éj": case "él": case "ém": case "én": case "ép":
                case "ér": case "és": case "ét": case "es": case "em":
                case "ep": case "er": case "ec": case "en": case "ev":

                case "el" when Exceptions.noDoubleL.Contains(stem + "er"):
                case "et" when Exceptions.noDoubleT.Contains(stem + "er"):

                    actualStem = ReplaceEwithEGrave(stem, stemEnding);
                    return true;

                case "el":
                case "et":

                    actualStem = DoubleLastLetter(stem);
                    return true;
            }

            // @formatter:on

            NoChange:
            actualStem = "";
            return false;
        }

        private static bool GetBaseStem3(string stem, out string actualStem)
        {
            const int endingLength = 3;
            if (stem.Length < endingLength)
            {
                goto NoChange;
            }

            string stemEnding = stem.Substring(stem.Length - endingLength);

            // @formatter:off

            switch (stemEnding)
            {
                case "éch": case "égu": case "ébr": case "égl": case "évr":
                case "étr": case "équ": case "égr": case "égn": case "écr":
                case "evr":
                    actualStem = ReplaceEwithEGrave(stem, stemEnding);
                    return true;
            }

            // @formatter:on

            NoChange:
            actualStem = "";
            return false;
        }

        private static bool GetBaseStem4(string stem, out string actualStem)
        {
            const int endingLength = 4;

            if (stem.Length < endingLength)
            {
                goto NoChange;
            }

            string stemEnding = stem.Substring(stem.Length - endingLength);
            if (stemEnding == "mour")
            {
                actualStem = stem.ReplaceAt(stem.Length - 3, 'e');
                return true;
            }

            NoChange:
            actualStem = "";
            return false;
        }

        private static string ReplaceEwithEGrave(string stem, string stemEnding)
        {
            int index = stem.Length - stemEnding.Length;
            return stem.ReplaceAt(index, 'è');
        }

        private static string DoubleLastLetter(string stem)
        {
            return stem + stem[^1];
        }
    }
}