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
                return new [] {"vais", "vas", "va", "allons", "allez", "vont"};
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

            if (verb.Length > 5)
            {
                string substring3 = verb.Substring(verb.Length - 6, 4);
                if (substring3 == "mour")
                {
                    string stemJeTuIlIls = ReplaceAt(stem, verb.Length - 5, 'e');
                    return AddEndings(endings, stemJeTuIlIls, stem);
                }
            }

            // for précéder (but not planchéier)
            if (verb[^3] != 'i')
            {
                int replacedCharIndex1 = verb.Length - 4;
                char vowel = stem[replacedCharIndex1];
                if (replacedCharIndex1 > 0 && vowel == 'é')
                {
                    return ConvertEtoEaigu(endings, stem, replacedCharIndex1);
                }
            }

            string substring = verb.Substring(verb.Length-4, 2);
            if (new[] {"es", "em", "ep", "er", "ec"}.Contains(substring))
            {
                int replacedCharIndex = verb.Length - 4;
                char vowel = stem[replacedCharIndex];
                if (replacedCharIndex > 0 && (vowel == 'e'))
                {
                    return ConvertEtoEaigu(endings, stem, replacedCharIndex);
                }
            }

            if (new[] {"ch", "gu", "br", "gl", "vr", "tr", "qu", "gr", "gn", "cr" }.Contains(substring))
            {
                int replacedCharIndex = verb.Length - 5;
                char vowel = stem[replacedCharIndex];
                if (replacedCharIndex > 0 && (vowel == 'é' || vowel == 'e'))
                {
                    return ConvertEtoEaigu(endings, stem, replacedCharIndex);
                }
            }

            if (substring == "en")
            {
                int replacedCharIndex = verb.Length - 4;
                if (replacedCharIndex > 0 && stem[replacedCharIndex] == 'e')
                {
                    return ConvertEtoEaigu(endings, stem, replacedCharIndex);
                }
            }

            // for acheter but not annexer
            if (! new[] {'x', 'f', 'w', 'y'}.Contains(verb[^3]))
            {
                int replacedCharIndex = verb.Length - 4;
                if (replacedCharIndex > 0 && stem[replacedCharIndex] == 'e')
                {
                    if (stem[replacedCharIndex + 1] == 'l')
                    {
                        bool isException = Exceptions.noDoubleL.Contains(verb);
                        return DoubleConsonant(endings, stem, replacedCharIndex, isException);
                    }

                    if (stem[replacedCharIndex + 1] == 't')
                    {
                        bool isException = Exceptions.noDoubleT.Contains(verb);
                        return DoubleConsonant(endings, stem, replacedCharIndex, isException);
                    }

                    if (stem[replacedCharIndex + 1] == 'v')
                    {
                        // achever
                        return ConvertEtoEaigu(endings, stem, replacedCharIndex);
                    }
                }
            }

            // for aboyer, appuyer
            int replacedCharIndex2 = verb.Length - 3;
            string substring1 = stem.Substring(replacedCharIndex2-1, 2);
            if (replacedCharIndex2 > 0 && 
                (replacedCharIndex2 + 1 <= stem.Length) && (substring1 == "oy" || substring1 == "uy"))
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
            return new StringBuilder(inString) { [actualIndex] = c }.ToString();
        }
    }
}