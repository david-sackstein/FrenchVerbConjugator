namespace ConjugatorLibrary
{
    public static class ConditionelConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            string stem = FutureConjugator.GetStem(verb);

            string[] endings = ImparfaitConjugator.Endings;

            return stem.AddEndings(endings);
        }
    }
}