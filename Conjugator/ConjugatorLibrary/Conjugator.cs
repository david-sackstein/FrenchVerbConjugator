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

            // for manger
            string onsEnding = "ons";
            if (verb[^3] == 'g')
            {
                // soften the g before an 'o'
                onsEnding = "e" + onsEnding;
            }

            string[] endings = {"e", "es", "e", onsEnding, "ez", "ent"};
            string[] withEndings = Apply(endings, verb);

            if (verb[^3] == 'c')
            {
                // soften the c with a cedilla before an 'o'
                withEndings[3] = ReplaceAt(withEndings[3], -4, 'ç');
            }

            return withEndings;
        }

        private static string[] Apply(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            if (stem.Length > 2)
            {
                string substring = stem.Substring(stem.Length - 2, 2);

                switch (substring)
                {
                    case "oy":
                    case "uy":
                    {
                        string stemJeTuIlIls = ReplaceAt(stem, verb.Length - 3, 'i');
                        return AddEndings(endings, stemJeTuIlIls, stem);
                    }

                    case "éc": case "éd": case "ég": case "éj": case "él": case "ém":
                    case "én": case "ép": case "ér": case "és": case "ét": case "es":
                    case "em": case "ep": case "er": case "ec": case "en": case "ev":

                    case "el" when Exceptions.noDoubleL.Contains(verb):
                    case "et" when Exceptions.noDoubleT.Contains(verb):

                        return ConvertEtoEaigu(endings, stem, stem.Length - substring.Length);

                    case "el":
                    case "et":

                        return DoubleConsonant(endings, stem);
                }
            }

            if (stem.Length > 3)
            {
                string substring = verb.Substring(stem.Length - 3, 3);

                switch (substring)
                {
                    case "éch": case "égu": case "ébr": case "égl": case "évr":
                    case "étr": case "équ": case "égr": case "égn": case "écr":
                    case "evr":
                        return ConvertEtoEaigu(endings, stem, stem.Length - substring.Length);
                }
            }

            if (stem.Length > 4)
            {
                string substring = verb.Substring(stem.Length - 4, 4);

                if (substring == "mour")
                {
                    string stemJeTuIlIls = ReplaceAt(stem, stem.Length - 3, 'e');
                    return AddEndings(endings, stemJeTuIlIls, stem);
                }
            }

            return endings.Select(ending => stem + ending).ToArray();
        }

        private static string[] ConvertEtoEaigu(string[] endings, string stem, int replacedCharIndex)
        {
            string actualStem = ReplaceAt(stem, replacedCharIndex, 'è');
            return AddEndings(endings, actualStem, stem);
        }

        private static string[] DoubleConsonant(string[] endings, string stem)
        {
            string actualStem = stem + stem[^1];
            return AddEndings(endings, actualStem, stem);
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