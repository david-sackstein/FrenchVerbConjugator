using System;
using System.Linq;

namespace ConjugatorLibrary.SecondGroup;

public static class ParticipePasseConjugator
{
    private static string[] Endings { get; } = { "i", "is", "ie", "ies" };

    public static string[] GetConjugations(string verb)
    {
        Func<string, (bool, string[])>[] irregularHandlers =
        {
            ExplicitExceptions,
            WithIsEndings,
            WithErtEndings,
            AddUEndings
        };

        foreach (var handler in irregularHandlers)
        {
            (var isHandled, var conjugations) = handler(verb);
            if (isHandled) return conjugations;
        }

        // regular

        var stem = GetStem(verb);
        return Endings.AddEndings(stem);
    }

    private static (bool, string[]) ExplicitExceptions(string verb)
    {
        return verb switch
        {
            "avoir" => (true, ["eu", "eus", "eue", "eues"]),
            "pouvoir" => (true, ["pu", "pu", "pu", "pu"]),
            "pleuvoir" => (true, ["plu", "plu", "plu", "plu"]),
            "falloir" => (true, ["fallu", "fallu", "fallu", "fallu"]),
            "mourir" => (true, ["mort", "morts", "morte", "mortes"]),
            "mouvoir" => (true, ["mû", "mûs", "mûe", "mûes"]), // dubious because devoir doesnt work like this
            _ => (false, null)
        };
    }

    private static (bool, string[]) AddUEndings(string verb)
    {
        (bool, string[]) _AddUEndings(string stem)
        {
            string[] uEndings = { "u", "us", "ue", "ues" };
            return (true, uEndings.AddEndings(stem));
        }

        if (Exceptions.devoirVerbs.Contains(verb))
        {
            var shortenedStem = verb.TrimEnd("evoir");
            string[] withCircumflex = { "û", "us", "ue", "ues" };
            return (true, withCircumflex.AddEndings(shortenedStem));
        }

        if (Exceptions.cevoirVerbs.Contains(verb))
        {
            var shortenedStem = verb.TrimEnd("cevoir") + "ç";
            return _AddUEndings(shortenedStem);
        }

        if (verb == "savoir")
        {
            var shortenedStem = verb.TrimEnd("avoir");
            return _AddUEndings(shortenedStem);
        }

        if (verb == "promouvoir" || verb == "émouvoir")
        {
            var shortenedStem = verb.TrimEnd("ouvoir");
            return _AddUEndings(shortenedStem);
        }

        if (new[] { "dévêtir", "férir", "revêtir", "vêtir", "issir" }.Contains(verb))
        {
            var stem = verb.TrimEnd("ir");
            return _AddUEndings(stem);
        }

        if (verb.EndsWith("oir"))
        {
            var shortenedStem = verb.TrimEnd("oir");
            return _AddUEndings(shortenedStem);
        }

        if (verb.EndsWith("enir") || verb.EndsWith("ourir"))
        {
            var stem = verb.TrimEnd("ir");
            return _AddUEndings(stem);
        }

        return (false, null);
    }

    private static (bool, string[]) WithErtEndings(string verb)
    {
        if (Exceptions.verbsWithErtEndings.Contains(verb))
        {
            var shortenedStem = verb.TrimEnd("rir");
            string[] endings = { "ert", "erts", "erte", "ertes" };
            return (true, endings.AddEndings(shortenedStem));
        }

        return (false, null);
    }

    private static (bool, string[]) WithIsEndings(string verb)
    {
        string[] endings = { "is", "is", "ise", "ises" };

        if (verb.EndsWith("eoir"))
        {
            var shortenedStem = verb.TrimEnd("eoir");
            return (true, endings.AddEndings(shortenedStem));
        }

        if (verb.EndsWith("uérir") && verb != "guérir")
        {
            var shortenedStem = verb.TrimEnd("érir");
            return (true, endings.AddEndings(shortenedStem));
        }

        if (verb == "rassir")
        {
            var stem = verb.TrimEnd("ir");
            return (true, endings.AddEndings(stem));
        }

        return (false, null);
    }

    private static string GetStem(string verb)
    {
        return verb.Remove(verb.Length - 2);
    }
}