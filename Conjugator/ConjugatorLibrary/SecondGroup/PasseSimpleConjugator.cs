using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class PasseSimpleConjugator
    {
        private static string[] isEndings { get; } = {"is", "is", "it", "îmes", "îtes", "irent"};
        private static string[] usEndings { get; } = {"us", "us", "ut", "ûmes", "ûtes", "urent"};

        public static string[] GetConjugations(string verb)
        {
            if (verb == "pleuvoir")
            {
                return new[] {"", "", "plut", "", "", "plurent"};
            }

            if (verb == "avoir")
            {
                return usEndings.AddEndings("e");
            }

            if (verb == "savoir")
            {
                return usEndings.AddEndings("s");
            }

            var parts = GetConjugationParts(verb);

            return parts.GetConjugation();
        }

        private static ConjugationParts GetConjugationParts(string verb)
        {
            if (verb.EndsWith("ourir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("ir"),
                    usEndings);
            }

            if (verb.EndsWith("enir"))
            {
                var stem1 = verb.TrimEnd("enir");
                var endings1 = isEndings.Select(s => s.Insert(1, "n")).ToArray();
                return new ConjugationParts(stem1, endings1);
            }

            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                return new ConjugationParts(
                    verb.TrimEnd("cevoir") + "ç",
                    usEndings);
            }

            if (verb.EndsWith("ourir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("ir"),
                    usEndings);
            }

            if (verb.EndsWith("ouvoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("ouvoir"),
                    usEndings);
            }

            if (verb.EndsWith("devoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("evoir"),
                    usEndings);
            }

            if (verb.EndsWith("eoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("eoir"),
                    isEndings);
            }

            if (verb.EndsWith("quérir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("érir"),
                    isEndings);
            }

            var stem = GetStem(verb);
            var endings = isEndings;

        
            return new ConjugationParts(stem, endings);
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