namespace ConjugatorLibrary.FirstGroup;

public static class ParticipePresentConjugator
{
    public static string[] GetConjugations(string verb)
    {
        var stem = GetStem(verb);
        return [stem + "ant"];
    }

    private static string GetStem(string verb)
    {
        var stem = verb.Remove(verb.Length - 2);
        if (verb[^3] == 'g') return stem + "e";

        if (verb[^3] == 'c') return stem.ReplaceAt(-1, 'ç');

        return stem;
    }
}