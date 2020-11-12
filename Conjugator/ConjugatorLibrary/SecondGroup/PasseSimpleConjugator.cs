using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class PasseSimpleConjugator
    {
        private static string[] issEndings { get; } = {"is", "is", "it", "îmes", "îtes", "irent"};
        private static string[] ussEndings { get; } = {"us", "us", "ut", "ûmes", "ûtes", "urent"};

        public static string[] GetConjugations(string verb)
        {
            if (verb == "pleuvoir")
            {
                return new[] {"", "", "plut", "", "", "plurent"};
            }

            if (verb == "avoir")
            {
                return ussEndings.AddEndings("e");
            }

            if (verb == "savoir")
            {
                return ussEndings.AddEndings("s");
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
                    ussEndings);
            }

            if (verb.EndsWith("oir"))
            {
                return GetOirConjugationParts(verb);
            }

            if (verb.EndsWith("quérir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("érir"),
                    issEndings);
            }

            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                var endings = issEndings.Select(s => s.Insert(1, "n")).ToArray();
                return new ConjugationParts(stem, endings);
            }

            var regularStem = verb.TrimEnd("ir");
            return new ConjugationParts(regularStem, issEndings);
        }

        private static ConjugationParts GetOirConjugationParts(string verb)
        {
            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                return new ConjugationParts(
                    verb.TrimEnd("cevoir") + "ç",
                    ussEndings);
            }

            if (verb.EndsWith("ouvoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("ouvoir"),
                    ussEndings);
            }

            if (verb.EndsWith("devoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("evoir"),
                    ussEndings);
            }

            if (verb.EndsWith("eoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("eoir"),
                    issEndings);
            }

            var stem = verb.TrimEnd("oir");

            return verb == "revoir" || verb == "entrevoir" || verb == "prévoir" || verb == "voir"
                ? new ConjugationParts(stem, issEndings)
                : new ConjugationParts(stem, ussEndings);
        }
    }
}