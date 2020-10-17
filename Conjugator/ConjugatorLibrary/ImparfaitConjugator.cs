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

            string stem = GetStem(verb);

            string[] endings = {"ais", "ais", "ait", "ions", "iez", "aient"};
            if (verb[^3] == 'g')
            {
                endings = endings.ForNonNousVous(s => "e" + s);
            }

            string[] withEndings = AddEndings(endings, stem);

            // soften the c with a cedilla before an 'a'
            if (verb[^3] == 'c')
            {
                withEndings = withEndings.ForNonNousVous(s => s.ReplaceAt(stem.Length - 1, 'ç'));
            }

            return withEndings;
        }

        private static string GetStem(string verb)
        {
            if (verb == "aller")
            {
                return "all";
            }
            return verb.Remove(verb.Length - 2);
        }

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}