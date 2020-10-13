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

            string onsEnding = "ons";
            if (verb[^3] == 'g')
            {
                // soften the g before an 'o'
                onsEnding = "e" + onsEnding;
            }

            string[] endings = {"e", "es", "e", onsEnding, "ez", "ent"};
            return Apply(endings, verb);
        }

        private static string[] Apply(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            int replacedCharIndex = verb.Length - 4;
            if (replacedCharIndex > 0 && stem[replacedCharIndex] == 'é')
            {
                string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex, 'è');
                return new[]
                {
                    stemJeTuIlIls + endings[0],
                    stemJeTuIlIls + endings[1],
                    stemJeTuIlIls + endings[2],
                    stem + endings[3],
                    stem + endings[4],
                    stemJeTuIlIls + endings[5],
                };
            }

            replacedCharIndex = verb.Length - 4;
            if (replacedCharIndex > 0 && stem[replacedCharIndex] == 'e')
            {
                string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex, 'è');
                return new[]
                {
                    stemJeTuIlIls + endings[0],
                    stemJeTuIlIls + endings[1],
                    stemJeTuIlIls + endings[2],
                    stem + endings[3],
                    stem + endings[4],
                    stemJeTuIlIls + endings[5],
                };
            }

            replacedCharIndex = verb.Length - 3;
            if (replacedCharIndex > 0 && stem[replacedCharIndex] == 'y')
            {
                string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex, 'i');
                return new[]
                {
                    stemJeTuIlIls + endings[0],
                    stemJeTuIlIls + endings[1],
                    stemJeTuIlIls + endings[2],
                    stem + endings[3],
                    stem + endings[4],
                    stemJeTuIlIls + endings[5],
                };
            }

            return endings.Select(ending => stem + ending).ToArray();
        }

        private static string ReplaceAt(string inString, int index, char c)
        {
            return new StringBuilder(inString) {[index] = c}.ToString();
        }
    }
}