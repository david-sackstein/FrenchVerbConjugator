using System.Data;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifImparfaitConjugator
    {
        private static readonly string[] Endings = {"isse", "isses", "ît", "issions", "issiez", "issent"};

        public static string[] GetConjugations(string verb)
        {
            var uEndings = new[] { "usse", "usses", "ût", "ussions", "ussiez", "ussent" };

            if (verb == "avoir")
            {
                return uEndings.AddEndings("e");
            }

            string stem = verb.Remove(verb.Length - 2);

            if (verb.EndsWith("enir"))
            {
                var modifiedStem = verb.TrimEnd("enir");
                var modifiedEndings = Endings.Select(s => s.Insert(1, "n")).ToArray();
                return modifiedEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("ourir"))
            {
                return uEndings.AddEndings(stem);
            }

            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                string modifiedStem = verb.TrimEnd("cevoir") + "ç";
                return uEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("quérir"))
            {
                stem = verb.TrimEnd("érir");
            }

            if (verb.EndsWith("eoir"))
            {
                stem = verb.TrimEnd("eoir");
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("ouvoir"))
            {
                stem = verb.TrimEnd("ouvoir");
                return uEndings.AddEndings(stem);
            }

            if (verb.EndsWith("revoir"))
            {
                string modifiedStem = verb.TrimEnd("oir");
                return Endings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("devoir"))
            {
                string modifiedStem = verb.TrimEnd("evoir");
                return uEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("oir"))
            {
                string modifiedStem = verb.TrimEnd("oir");
                return uEndings.AddEndings(modifiedStem);
            }

            return Endings.AddEndings(stem);
        }
    }
}