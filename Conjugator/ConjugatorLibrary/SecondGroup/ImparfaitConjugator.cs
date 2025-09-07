namespace ConjugatorLibrary.SecondGroup;

internal static class ImparfaitConjugator
{
    public static string[] Endings { get; } = { "ais", "ais", "ait", "ions", "iez", "aient" };

    public static string[] GetConjugations(string verb)
    {
        if (verb == "falloir") return ["", "", "fallait", "", "", ""];

        if (verb == "pleuvoir") return ["", "", "pleuvait", "", "", "pleuvaient"];

        if (verb == "seoir") return ["", "", "seyait", "", "", "seyaient"];

        if (verb == "messeoir") return ["", "", "messeyait", "", "", "messeyaient"];

        if (verb == "chaloir") return new string[6];

        var present = PresentConjugator.GetConjugations(verb);
        var nousForm = present[3];
        var stem = nousForm.TrimEnd("ons");
        return Endings.AddEndings(stem);
    }
}