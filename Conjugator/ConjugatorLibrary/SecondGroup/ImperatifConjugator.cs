namespace ConjugatorLibrary.SecondGroup
{
    public static class ImperatifConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return new[] {"", "aie", "" , "ayons", "ayez", ""  };
            }

            string[] present = PresentConjugator.GetConjugations(verb);
            return new[]
            {
                null,
                present[1], // tu
                null,
                present[3], // nous
                present[4], // vous
                null
            };
        }
    }
}