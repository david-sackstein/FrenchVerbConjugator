using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifImparfaitConjugator
    {
        private static readonly string[] issEndings = {"isse", "isses", "ît", "issions", "issiez", "issent"};
        private static readonly string[] ussEndings = {"usse", "usses", "ût", "ussions", "ussiez", "ussent"};

        public static string[] GetConjugations(string verb)
        {
            if (verb == "pleuvoir")
            {
                return new[] {"", "", "plût", "", "", ""};
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