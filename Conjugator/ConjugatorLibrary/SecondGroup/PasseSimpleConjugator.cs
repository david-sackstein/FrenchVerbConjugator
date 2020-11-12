using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class PasseSimpleConjugator
    {
        private static string[] Endings { get; } = {"is", "is", "it", "îmes", "îtes", "irent" };

        public static string[] GetConjugations(string verb)
        {
            if (verb.EndsWith("enir"))
            {
                var stem1 = verb.TrimEnd("enir");
                var endings1 = Endings.Select(s => s.Insert(1, "n")).ToArray();
                var parts = new ConjugationParts(stem1, endings1);
                return parts.GetConjugation();
            }

            string stem = GetStem(verb);
            string[] endings = Endings;

            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = Endings.SelectExceptFor(5, s => "e" + s).ToArray();
            }

            string[] withEndings = endings.AddEndings(stem);

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