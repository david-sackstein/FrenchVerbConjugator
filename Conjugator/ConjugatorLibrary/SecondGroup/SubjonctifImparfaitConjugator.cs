using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifImparfaitConjugator
    {
        private static readonly string[] issEndings = {"isse", "isses", "ît", "issions", "issiez", "issent"};
        private static readonly string[] ussEndings = { "usse", "usses", "ût", "ussions", "ussiez", "ussent" };
        
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

            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                var modifiedEndings = issEndings.Select(s => s.Insert(1, "n")).ToArray();
                return modifiedEndings.AddEndings(stem);
            }

            if (verb.EndsWith("ourir"))
            {
                string stem = verb.Remove(verb.Length - 2);
                return ussEndings.AddEndings(stem);
            }

            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                string modifiedStem = verb.TrimEnd("cevoir") + "ç";
                return ussEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("quérir"))
            {
                string stem = verb.TrimEnd("érir");
                return issEndings.AddEndings(stem);
            }

            if (verb.EndsWith("eoir"))
            {
                string stem = verb.TrimEnd("eoir");
                return issEndings.AddEndings(stem);
            }

            if (verb.EndsWith("ouvoir"))
            {
                string stem = verb.TrimEnd("ouvoir");
                return ussEndings.AddEndings(stem);
            }

            if (verb.EndsWith("revoir"))
            {
                string modifiedStem = verb.TrimEnd("oir");
                return issEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("devoir"))
            {
                string modifiedStem = verb.TrimEnd("evoir");
                return ussEndings.AddEndings(modifiedStem);
            }

            if (verb == "prévoir" || verb == "voir")
            {
                string modifiedStem = verb.TrimEnd("oir");
                return issEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("oir"))
            {
                string modifiedStem = verb.TrimEnd("oir");
                return ussEndings.AddEndings(modifiedStem);
            }

            string regularStem = verb.Remove(verb.Length - 2);
            return issEndings.AddEndings(regularStem);
        }
    }
}