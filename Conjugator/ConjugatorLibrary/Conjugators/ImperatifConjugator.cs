namespace ConjugatorLibrary
{
    public static class ImperatifConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            var present = PresentConjugator.GetConjugations(verb);
            return new[]
            {
                "NA",
                present[1].TrimEnd('s'), // tu
                "NA",
                present[3] // nous
            };
        }
    }
}