using System.Linq;

namespace ConjugatorLibrary
{
    public static class ParticipePasseConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);

            string[] endings = { "é", "és", "ée", "ées" };
            string[] withEndings = AddEndings(endings, stem);
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

        private static string[] AddEndings(string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }
    }
}