using System.Linq;

namespace ConjugatorLibrary
{
    public static class PasseSimpleConjugator
    {
        static string[] Endings { get; } = {"ai", "as", "a", "âmes", "âtes", "èrent" };

        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);

            var endings = Endings;

            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = Endings.Select((ending, i) => i != 5 ? "e" + ending : ending).ToArray();
            }

            return stem.AddEndings(endings);
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