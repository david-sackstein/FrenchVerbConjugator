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

            if (verb.EndsWith("tenir"))
            {
                var modifiedStem = verb.TrimEnd("enir");
                var modifiedEndings = Endings.Select(s => s.Insert(1, "n")).ToArray();
                return modifiedEndings.AddEndings(modifiedStem);
            }

            if (verb.EndsWith("ourir"))
            {
                return uEndings.AddEndings(stem);
            }

            // soften the c with a cedilla before the 'a'
            if (verb[^3] == 'c')
            {
                stem = stem.ReplaceAt(-1, 'ç');
            }

            string[] endings = Endings;
            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = Endings.Select(ending => "e" + ending).ToArray();
            }

            return endings.AddEndings(stem);
        }
    }
}