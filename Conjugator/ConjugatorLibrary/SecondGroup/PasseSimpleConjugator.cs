using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class PasseSimpleConjugator
    {
        private static string[] isEndings { get; } = {"is", "is", "it", "îmes", "îtes", "irent"};
        private static string[] usEndings { get; } = {"us", "us", "ut", "ûmes", "ûtes", "urent"};

        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return usEndings.AddEndings("e");
            }

            if (verb.EndsWith("enir"))
            {
                var stem1 = verb.TrimEnd("enir");
                var endings1 = isEndings.Select(s => s.Insert(1, "n")).ToArray();
                var parts = new ConjugationParts(stem1, endings1);
                return parts.GetConjugation();
            }

            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                var parts = new ConjugationParts(
                    verb.TrimEnd("cevoir") + "ç",
                    usEndings);
                return parts.GetConjugation();
            }

            if (verb.EndsWith("ourir"))
            {
                var parts = new ConjugationParts(
                    verb.TrimEnd("ir"),
                    usEndings);
                return parts.GetConjugation();
            }

            if (verb.EndsWith("ouvoir"))
            {
                var parts = new ConjugationParts(
                    verb.TrimEnd("ouvoir"),
                    usEndings);
                return parts.GetConjugation();
            }

            if (verb.EndsWith("quérir"))
            {
                var parts = new ConjugationParts(
                    verb.TrimEnd("érir"),
                    isEndings);
                return parts.GetConjugation();
            }

            var stem = GetStem(verb);
            var endings = isEndings;

            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = isEndings.SelectExceptFor(5, s => "e" + s).ToArray();
            }

            var withEndings = endings.AddEndings(stem);

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