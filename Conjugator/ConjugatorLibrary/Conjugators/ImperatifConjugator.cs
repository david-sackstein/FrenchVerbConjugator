namespace ConjugatorLibrary
{
    public static class ImperatifConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            string[] present = PresentConjugator.GetConjugations(verb);
            return new[]
            {
                null,
                present[1].TrimEnd('s'), // tu
                null,
                present[3], // nous
                present[4], // vous
                null
            };
        }
    }
}