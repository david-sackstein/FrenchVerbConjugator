namespace ConjugatorLibrary.SecondGroup;

public static class PasseSimpleConjugator
{
    private static string[] isEndings { get; } = { "is", "is", "it", "îmes", "îtes", "irent" };
    private static string[] usEndings { get; } = { "us", "us", "ut", "ûmes", "ûtes", "urent" };
    private static readonly PasseSimpleSubjectifImparfaitConjugatorImpl impl = new(isEndings, usEndings);

    public static string[] GetConjugations(string verb)
    {
        if (verb == "pleuvoir") return ["", "", "plut", "", "", "plurent"];

        return impl.GetConjugations(verb);
    }
}