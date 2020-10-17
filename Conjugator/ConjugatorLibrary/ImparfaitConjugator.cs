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

            string[] endings = {"ais", "ais", "ait", "ions", "iez", "aient"};
            if (verb[^3] == 'g')
            {
                endings = new[]
                {
                    "e" + endings[0],
                    "e" + endings[1],
                    "e" + endings[2],
                    endings[3],
                    endings[4],
                    "e" + endings[5],
                };
            }

            string[] withEndings = ApplyEndings(endings, verb);

            // soften the c with a cedilla before an 'o' for nous (at index 3)
            if (verb[^3] == 'c')
            {
                withEndings[0] = withEndings[0].ReplaceAt(-4, 'ç');
                withEndings[1] = withEndings[1].ReplaceAt(-4, 'ç');
                withEndings[2] = withEndings[2].ReplaceAt(-4, 'ç');
                //withEndings[3] = withEndings[3].ReplaceAt(-4, 'ç');
                //withEndings[4] = withEndings[4].ReplaceAt(-4, 'ç');
                withEndings[5] = withEndings[5].ReplaceAt(-6, 'ç');
            }

            return withEndings;
        }

        private static string[] ApplyEndings(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            // determine the stem for je, tu, il, ils ("modifiedStem") which may
            // not be the same as for nous and vous

            return AddEndings(endings, stem);
        }

        private static string[] AddEndings(string[] endings, string modifiedStem, string nousVousStem)
        {
            return new[]
            {
                modifiedStem + endings[0],
                modifiedStem + endings[1],
                modifiedStem + endings[2],
                nousVousStem + endings[3],
                nousVousStem + endings[4],
                modifiedStem + endings[5],
            };
        }

        private static string[] AddEndings(string[] endings, string modifiedStem)
        {
            return endings.Select(ending => modifiedStem + ending).ToArray();
        }
    }
}