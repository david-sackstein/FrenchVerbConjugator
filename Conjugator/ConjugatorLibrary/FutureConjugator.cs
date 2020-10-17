using System.Diagnostics.Contracts;
using System.Linq;

namespace ConjugatorLibrary
{
    public class FutureConjugator
    {
        public string[] GetErFuture(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));
            Contract.Requires(verb.Length > 2);

            string stem = GetStem(verb);

            string[] endings = {"ai", "as", "a", "ons", "ez", "ont"};
            if (verb[^3] == 'g')
            {
                endings = endings.MatchNousVous(s => "e" + s);
            }

            string[] withEndings = AddEndings(endings, stem);

            //// soften the c with a cedilla before an 'a'
            //if (verb[^3] == 'c')
            //{
            //    withEndings = withEndings.MatchNousVous(s => s.ReplaceAt(stem.Length - 1, 'ç'));
            //}

            return withEndings;
        }

        private static string GetStem(string verb)
        {
            if (verb == "aller")
            {
                return "ir";
            }
            return verb;
        }

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}