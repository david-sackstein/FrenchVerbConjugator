namespace ConjugatorLibrary.FirstGroup;

public static class ImparfaitConjugator
{
    public static string[] Endings { get; } = { "ais", "ais", "ait", "ions", "iez", "aient" };

    public static string[] GetConjugations(string verb)
    {
        var stem = GetStem(verb);

        var endings = Endings;

        if (verb[^3] == 'g') endings = endings.MatchNousVous(s => "e" + s);

        var withEndings = endings.AddEndings(stem);

        // soften the c with a cedilla before an 'a'
        if (verb[^3] == 'c') withEndings = withEndings.MatchNousVous(s => s.ReplaceAt(stem.Length - 1, 'ç'));

        return withEndings;
    }

    private static string GetStem(string verb)
    {
        if (verb == "aller") return "all";

        return verb.Remove(verb.Length - 2);
    }
}