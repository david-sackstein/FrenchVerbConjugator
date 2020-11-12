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

            var stemEndings = wweew(verb);

            return stemEndings.Endings.AddEndings(stemEndings.Stem);
        }

        private static StemEndings wweew(string verb)
        {
            if (verb.EndsWith("ourir"))
            {
                var stem = verb.TrimEnd("ir");
                return new StemEndings(stem, ussEndings);
            }

            if (verb.EndsWith("oir"))
            {
                return OirVerbs(verb);
            }

            if (verb.EndsWith("quérir"))
            {
                var stem = verb.TrimEnd("érir");
                return new StemEndings(stem, issEndings);
            }

            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                var endings = issEndings.Select(s => s.Insert(1, "n")).ToArray();
                return new StemEndings(stem, endings);
            }

            var regularStem = verb.TrimEnd("ir");
            return new StemEndings(regularStem, issEndings);
        }

        private static StemEndings OirVerbs(string verb)
        {
            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                var stem = verb.TrimEnd("cevoir") + "ç";
                return new StemEndings(stem, ussEndings);
            }

            if (verb.EndsWith("ouvoir"))
            {
                var stem = verb.TrimEnd("ouvoir");
                return new StemEndings(stem, ussEndings);
            }

            if (verb.EndsWith("devoir"))
            {
                var stem = verb.TrimEnd("evoir");
                return new StemEndings(stem, ussEndings);
            }

            if (verb.EndsWith("eoir"))
            {
                var stem = verb.TrimEnd("eoir");
                return new StemEndings(stem, issEndings);
            }

            {
                var stem = verb.TrimEnd("oir");

                if (verb == "revoir" || verb == "entrevoir" || verb == "prévoir" || verb == "voir")
                {
                    return new StemEndings(stem, issEndings);
                }

                return new StemEndings(stem, ussEndings);
            }
        }
    }
}