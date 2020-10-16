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

            int replacedCharIndex4 = verb.Length - 4;
            char vowel4 = stem[replacedCharIndex4];

            // for précéder (but not planchéier)
            if (vowel4 == 'é')
            {
                if (verb[^3] != 'i')
                {
                    return ConvertEtoEaigu(endings, stem, replacedCharIndex4);
                }
            }

            string substring2 = verb.Substring(replacedCharIndex4, 2);
            
            switch (substring2)
            {
                case "el":
                {
                    bool isException = Exceptions.noDoubleL.Contains(verb);
                    return DoubleConsonant(endings, stem, replacedCharIndex4, isException);
                }
                case "et":
                {
                    bool isException = Exceptions.noDoubleT.Contains(verb);
                    return DoubleConsonant(endings, stem, replacedCharIndex4, isException);
                }

                case "es":
                case "em":
                case "ep":
                case "er":
                case "ec":
                case "en":
                case "ev":
                    return ConvertEtoEaigu(endings, stem, replacedCharIndex4);
            }

            if (verb.Length > 5)
            {
                string substring = verb.Substring(replacedCharIndex4-1, 3);

                if (new[]
                {
                    "ech", "egu", "ebr", "egl", "evr", "etr", "equ", "egr", "egn", "ecr",
                    "éch", "égu", "ébr", "égl", "évr", "étr", "équ", "égr", "égn", "écr"
                }.Contains(substring))
                {
                    int replacedCharIndex = verb.Length - 5;
                    char vowel = stem[replacedCharIndex];
                    if (vowel == 'é' || vowel == 'e')
                    {
                        return ConvertEtoEaigu(endings, stem, replacedCharIndex);
                    }
                }
            }

            if (verb.Length > 5)
            {
                string substring3 = verb.Substring(verb.Length - 6, 4);
                if (substring3 == "mour")
                {
                    string stemJeTuIlIls = ReplaceAt(stem, verb.Length - 5, 'e');
                    return AddEndings(endings, stemJeTuIlIls, stem);
                }
            }

            // for aboyer, appuyer
            int replacedCharIndex2 = verb.Length - 3;
            string substring1 = stem.Substring(replacedCharIndex2 - 1, 2);
            if (replacedCharIndex2 > 0 &&
                replacedCharIndex2 + 1 <= stem.Length && (substring1 == "oy" || substring1 == "uy"))
            {
                string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex2, 'i');
                return AddEndings(endings, stemJeTuIlIls, stem);
            }

            return endings.Select(ending => stem + ending).ToArray();
        }

        private static string[] DoubleConsonant(
            string[] endings, string stem,
            int replacedCharIndex, bool isException)
        {
            if (isException)
            {
                // celer
                return ConvertEtoEaigu(endings, stem, replacedCharIndex);
            }

            // agneler
            return DoubleConsonant(endings, stem);
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