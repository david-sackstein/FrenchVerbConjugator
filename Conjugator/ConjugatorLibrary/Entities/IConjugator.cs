using System;

namespace ConjugatorLibrary.Conjugators
{
    public interface IConjugator
    {
        Func<string, string[]> Conditionel { get; }
        Func<string, string[]> Future { get; }
        Func<string, string[]> Imparfait { get; }
        Func<string, string[]> Imperatif { get; }
        Func<string, string[]> ParticipePasse { get; }
        Func<string, string[]> ParticipePresent { get; }
        Func<string, string[]> PasseSimple { get; }
        Func<string, string[]> Present { get; }
        Func<string, string[]> SubjonctifImparfait { get; }
        Func<string, string[]> SubjonctifPresent { get; }
    }
}
