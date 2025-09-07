using System.Linq;

namespace ConjugatorLibrary.SecondGroup;

internal static class PresentConjugator
{
    public static string[] GetConjugations(string verb)
    {
        var explicitIrregular = IsExplicitIrregular(verb);

        if (explicitIrregular != null) return explicitIrregular;

        if (verb.EndsWith("mouvoir"))
        {
            string[] endings = ["meus", "meus", "meut", "mouvons", "mouvez", "meuvent"];
            return endings.AddEndings(verb.TrimEnd("mouvoir"));
        }

        if (verb.EndsWith("mourir"))
        {
            string[] endings = ["meurs", "meurs", "meurt", "mourons", "mourez", "meurent"];
            return endings.AddEndings(verb.TrimEnd("mourir"));
        }

        if (verb.EndsWith("valoir"))
        {
            string[] endings = ["aux", "aux", "aut", "alons", "alez", "alent"];
            return endings.AddEndings(verb.TrimEnd("aloir"));
        }

        var regularStem = verb.TrimEnd("ir");

        if (verb.EndsWith("courir")) return AddSstEndings(regularStem);

        if (verb.EndsWith("enir"))
        {
            var modifiedStem = regularStem.ReplaceEnd("en", "ien");
            return AddSstEndings(modifiedStem, regularStem, modifiedStem + 'n');
        }

        if (verb.EndsWith("bouillir"))
        {
            var singularStem = regularStem.TrimEnd("ill");
            return AddSstEndings(singularStem, regularStem, regularStem);
        }

        if (verb.EndsWith("sseoir") || verb.EndsWith("rseoir"))
        {
            var modifiedStem = regularStem.TrimEnd("eo") + "o";
            return AddYonsEndings(modifiedStem);
        }

        if (verb.EndsWith("vêtir")) return AddSstEndings(regularStem);

        if (verb.EndsWith("quérir"))
        {
            var singularStem = regularStem.TrimEnd("ér") + "ier";
            var ilsStem = regularStem.TrimEnd("ér") + "ièr";

            return AddSstEndings(singularStem, regularStem, ilsStem);
        }

        if (Exceptions.verbsWithYonsEndings.Contains(verb)) return AddYonsEndings(regularStem);

        if (verb == "savoir") return AddSstEndings("sai", "sav", "sav");

        if (Exceptions.devoirVerbs.Contains(verb))
        {
            var prefix = verb.TrimEnd("devoir");
            return AddSstEndings(prefix + "doi", prefix + "dev", prefix + "doiv");
        }

        if (Exceptions.cevoirVerbs.Contains(verb))
        {
            var prefix = verb.TrimEnd("cevoir");
            return AddSstEndings(prefix + "çoi", prefix + "cev", prefix + "çoiv");
        }

        if (Exceptions.verbsWithSstEndings.Contains(verb))
        {
            var singularStem = regularStem[..^1];
            return AddSstEndings(singularStem, regularStem, regularStem);
        }

        if (Exceptions.verbsWithErEndings.Contains(verb)) return AddErEndings(regularStem);

        return AddRegularEndings(regularStem);
    }

    private static string[] IsExplicitIrregular(string verb)
    {
        return verb switch
        {
            "avoir" => ["ai", "as", "a", "avons", "avez", "ont"],
            "vouloir" => ["veux", "veux", "veut", "voulons", "voulez", "veulent"],
            "pouvoir" => ["peux", "peux", "peut", "pouvons", "pouvez", "peuvent"],
            "faillir" => ["faux", "faux", "faut", "faillons", "faillez", "faillent"],
            "gésir" => ["gis", "gis", "gît", "gisons", "gisez", "gisent"],
            "seoir" => ["", "", "sied", "", "", "siéent"],
            "messeoir" => ["", "", "messied", "", "", "messiéent"],
            "pleuvoir" => ["", "", "pleut", "", "", "pleuvent"],
            "falloir" => ["", "", "faut", "", "", ""],
            "chaloir" => ["", "", "chaut", "", "", ""],
            _ => null
        };
    }

    private static string[] AddRegularEndings(string stem)
    {
        string[] endings = ["is", "is", "it", "issons", "issez", "issent"];
        return endings.AddEndings(stem);
    }

    private static string[] AddYonsEndings(string stem)
    {
        string[] endings = ["is", "is", "it", "yons", "yez", "ient"];
        return endings.AddEndings(stem);
    }

    private static string[] AddErEndings(string regularStem)
    {
        string[] endings = ["e", "es", "e", "ons", "ez", "ent"];
        return endings.AddEndings(regularStem);
    }

    private static string[] AddSstEndings(string singularStem, string nousVousStem, string ilsStem)
    {
        string[] endings = ["s", "s", "t", "ons", "ez", "ent"];
        return endings.AddEndings(singularStem, nousVousStem, ilsStem);
    }

    private static string[] AddSstEndings(string stem)
    {
        var ilEnding = stem[^1] == 't' ? "" : "t";
        string[] endings = { "s", "s", ilEnding, "ons", "ez", "ent" };
        return endings.AddEndings(stem);
    }
}