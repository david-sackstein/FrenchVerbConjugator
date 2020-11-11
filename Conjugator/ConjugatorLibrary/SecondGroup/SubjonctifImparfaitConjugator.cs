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

            string[] endings = Endings;

            return endings.AddEndings(stem);
        }
    }
}