using System.Diagnostics.Contracts;
using System.Linq;

namespace ConjugatorLibrary
{
    public class ImparfaitConjugator
    {
        public string[] GetErImparfait(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));
            Contract.Requires(verb.Length > 2);

            if (verb == "aller")
            {
                return new[] {"allais", "allais", "allait", "allions", "alliez", "allaient" };
            }

            // soften the g before an 'o'
            string nousEnding = "ions";
            if (verb[^3] == 'g')
            {
                nousEnding = "e" + nousEnding;
            }

            string[] endings = {"ais", "ais", "ait", nousEnding, "iez", "aient"};
            string[] withEndings = ApplyEndings(endings, verb);

            // soften the c with a cedilla before an 'o' for nous (at index 3)
            if (verb[^3] == 'c')
            {
                withEndings[3] = withEndings[3].ReplaceAt(-4, 'ç');
            }

            return withEndings;
        }

        private static string[] ApplyEndings(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            // determine the stem for je, tu, il, ils ("baseStem") which may
            // not be the same as for nous and vous

            return AddEndings(endings, stem);
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

        private static string[] AddEndings(string[] endings, string baseStem)
        {
            return endings.Select(ending => baseStem + ending).ToArray();
        }
    }
}