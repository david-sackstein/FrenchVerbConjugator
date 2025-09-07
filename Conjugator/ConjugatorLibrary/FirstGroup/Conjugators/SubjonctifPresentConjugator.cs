using System.Linq;

namespace ConjugatorLibrary.FirstGroup;

public static class SubjonctifPresentConjugator
{
    public static string[] GetConjugations(string verb)
    {
        if (verb == "aller") return ["aille", "ailles", "aille", "allions", "alliez", "aillent"];

        string[] endings = { "e", "es", "e", "ions", "iez", "ent" };

        return ApplyEndings(endings, verb);
    }

    private static string[] ApplyEndings(string[] endings, string verb)
    {
        var stem = verb.Remove(verb.Length - 2);

        // determine the stem for je, tu, il, ils ("modifiedStem") which may
        // not be the same as for nous and vous

        return PresentStemModifier.GetModifiedStem(stem, out var modifiedStem)
            ? AddEndings(endings, modifiedStem, stem)
            : AddEndings(endings, stem);
    }

    private static string[] AddEndings(string[] endings, string modifiedStem, string nousVousStem)
    {
        return endings.MatchNousVous(s => modifiedStem + s, s => nousVousStem + s);
    }

    private static string[] AddEndings(string[] endings, string modifiedStem)
    {
        return endings.Select(ending => modifiedStem + ending).ToArray();
    }
}