namespace ConjugatorLibrary.SecondGroup;

public static class ConditionelConjugator
{
    public static string[] GetConjugations(string verb)
    {
        var stem = FutureConjugator.GetStem(verb);

        var endings = ImparfaitConjugator.Endings;

        return endings.AddEndings(stem);
    }
}