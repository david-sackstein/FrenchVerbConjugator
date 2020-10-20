namespace ConjugatorLibrary.SecondGroup
{
    static class PresentConjugator
    {
        private static readonly string[] endings = {"is", "is" , "it", "issons", "issez", "issent" };

        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] {"ai", "as", "a", "avons", "avez", "ont"};
            }
            var stem = verb[..^2];
            return stem.AddEndings(endings);
        }
    }
}