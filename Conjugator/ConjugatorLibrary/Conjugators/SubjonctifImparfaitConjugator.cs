namespace ConjugatorLibrary
{
    public static class SubjonctifImparfaitConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            var stem = verb.Remove(verb.Length - 2);
            var endings = new[] {"asse", "asses", "ât", "assions", "assiez", "assent" };
            return stem.AddEndings(endings);
        }
    }
}