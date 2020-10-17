using System.Linq;

namespace ConjugatorLibrary
{
    public static class StemConverter
    {
        // The base stem is used for je, tu, il, ils but not for nous and vous
        public static bool GetBaseStem(string stem, out string baseStem)
        {
            if (stem.Length > 2)
            {
                string stemEnding = stem.Substring(stem.Length - 2);

                if (GetBaseStem2(stem, stemEnding, out baseStem))
                {
                    return true;
                }
            }

            if (stem.Length > 3)
            {
                string stemEnding = stem.Substring(stem.Length - 3);

                if (GetBaseStem3(stem, stemEnding, out baseStem))
                {
                    return true;
                }
            }

            if (stem.Length > 4)
            {
                string stemEnding = stem.Substring(stem.Length - 4);

                if (GetBaseStem4(stem, stemEnding, out baseStem))
                {
                    return true;
                }
            }

            baseStem = "";
            return false;
        }

        private static bool GetBaseStem2(string stem, string stemEnding, out string actualStem)
        {
            // @formatter:off

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

            actualStem = "";
            return false;
        }

        private static bool GetBaseStem3(string stem, string stemEnding, out string actualStem)
        {
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

            actualStem = "";
            return false;
        }

        private static bool GetBaseStem4(string stem, string stemEnding, out string actualStem)
        {
            if (stemEnding == "mour")
            {
                actualStem = stem.ReplaceAt(stem.Length - 3, 'e');
                return true;
            }

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