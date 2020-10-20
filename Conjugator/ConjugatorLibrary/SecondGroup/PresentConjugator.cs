namespace ConjugatorLibrary.SecondGroup
{
    static class PresentConjugator
    {
        private static readonly string[] endings = {"is", "is" , "it", "issons", "issez", "issent" };

        public static string[] GetConjugations(string verb)
        {
            var stem = verb[..^2];
            return stem.AddEndings(endings);
        }
    }
}