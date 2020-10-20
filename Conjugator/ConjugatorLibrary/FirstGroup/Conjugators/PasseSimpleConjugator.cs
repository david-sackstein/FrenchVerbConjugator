using System.Linq;

namespace ConjugatorLibrary.FirstGroup
{
    public static class PasseSimpleConjugator
    {
        private static string[] Endings { get; } = {"ai", "as", "a", "âmes", "âtes", "èrent"};

        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);
            string[] endings = Endings;

            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = Endings.SelectExceptFor(5, s => "e" + s).ToArray();
            }

            string[] withEndings = stem.AddEndings(endings);

            // soften the c with a cedilla
            if (verb[^3] == 'c')
            {
                return withEndings.SelectExceptFor(5, s => s.ReplaceAt(stem.Length - 1, 'ç')).ToArray();
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
    }
}