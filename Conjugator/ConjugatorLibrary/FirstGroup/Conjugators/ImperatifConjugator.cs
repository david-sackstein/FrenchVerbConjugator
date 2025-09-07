namespace ConjugatorLibrary.FirstGroup;

public static class ImperatifConjugator
{
    public static string[] GetConjugations(string verb)
    {
        var present = PresentConjugator.GetConjugations(verb);
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