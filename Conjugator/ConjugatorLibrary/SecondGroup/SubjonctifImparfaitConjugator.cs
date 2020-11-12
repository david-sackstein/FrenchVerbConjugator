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

            if (verb.EndsWith("ourir"))
            {
                var stem = verb.TrimEnd("ir");
                return ussEndings.AddEndings(stem);
            }

            if (verb.EndsWith("oir"))
            {
                if (Exceptions.cevoirVerbs.Contains(verb))
                {
                    var modifiedStem = verb.TrimEnd("cevoir") + "ç";
                    return ussEndings.AddEndings(modifiedStem);
                }

                if (verb.EndsWith("ouvoir"))
                {
                    var stem = verb.TrimEnd("ouvoir");
                    return ussEndings.AddEndings(stem);
                }

                if (verb.EndsWith("devoir"))
                {
                    var stem = verb.TrimEnd("evoir");
                    return ussEndings.AddEndings(stem);
                }

                if (verb.EndsWith("eoir"))
                {
                    var stem = verb.TrimEnd("eoir");
                    return issEndings.AddEndings(stem);
                }

                {
                    var stem = verb.TrimEnd("oir");

                    if (verb == "revoir" || verb == "entrevoir" || verb == "prévoir" || verb == "voir")
                    {
                        return issEndings.AddEndings(stem);
                    }

                    return ussEndings.AddEndings(stem);
                }
            }

            if (verb.EndsWith("quérir"))
            {
                var stem = verb.TrimEnd("érir");
                return issEndings.AddEndings(stem);
            }

            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                var modifiedEndings = issEndings.Select(s => s.Insert(1, "n")).ToArray();
                return modifiedEndings.AddEndings(stem);
            }

            var regularStem = verb.Remove(verb.Length - 2);
            return issEndings.AddEndings(regularStem);
        }
    }
}