using System;
using ConjugatorLibrary.Conjugators;

namespace ConjugatorLibrary.FirstGroup;

public class FirstGroupConjugator : IConjugator
{
    public bool IsInGroup(string verb)
    {
        return verb.EndsWith("er");
    }

    public Func<string, string[]> Conditionel => ConditionelConjugator.GetConjugations;
    public Func<string, string[]> Future => FutureConjugator.GetConjugations;
    public Func<string, string[]> Imparfait => ImparfaitConjugator.GetConjugations;
    public Func<string, string[]> Imperatif => ImperatifConjugator.GetConjugations;
    public Func<string, string[]> ParticipePasse => ParticipePasseConjugator.GetConjugations;
    public Func<string, string[]> ParticipePresent => ParticipePresentConjugator.GetConjugations;
    public Func<string, string[]> PasseSimple => PasseSimpleConjugator.GetConjugations;
    public Func<string, string[]> Present => PresentConjugator.GetConjugations;
    public Func<string, string[]> SubjonctifImparfait => SubjonctifImparfaitConjugator.GetConjugations;
    public Func<string, string[]> SubjonctifPresent => SubjonctifPresentConjugator.GetConjugations;
}