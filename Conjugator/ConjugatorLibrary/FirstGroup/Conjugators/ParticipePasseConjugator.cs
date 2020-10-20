namespace ConjugatorLibrary.FirstGroup
{
    public static class ParticipePasseConjugator
    {
        public static string[] Endings { get; } = {"é", "és", "ée", "ées"};

        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);

            return stem.AddEndings(Endings);
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