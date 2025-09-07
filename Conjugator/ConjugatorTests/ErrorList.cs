using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ConjugatorTests;

internal static class ErrorList
{
    private const string errorFileName = @"../../../errors.txt";

    public static void Save(string[] errorVerbs, Func<string, string[]> referenceConjugator,
        Func<string, string[]> conjugator)
    {
        string[][] errorVerbsWith =
            errorVerbs.Select(verb => Flatten(verb, referenceConjugator, conjugator)).ToArray();
        Save(errorVerbsWith);
    }

    public static string[] Load()
    {
        return LoadWithConjugations().Select(c => c[0]).ToArray();
    }

    public static string[][] LoadWithConjugations()
    {
        string text = File.ReadAllText(errorFileName);
        return JsonSerializer.Deserialize<string[][]>(text);
    }

    private static string[] Flatten(string verb, Func<string, string[]> referenceConjugator,
        Func<string, string[]> conjugator)
    {
        string[] expected = referenceConjugator(verb);
        string[] actual = conjugator(verb);
        IEnumerable<string> conjugation = expected.Zip(actual).Select(tuple => $"{tuple.First,-20}{tuple.Second}");
        return new[] {verb}.Concat(conjugation).ToArray();
    }

    private static void Save(string[][] errorVerbs)
    {
        string errors = JsonSerializer.Serialize(errorVerbs, new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        });
        File.WriteAllText(errorFileName, errors);
    }
}