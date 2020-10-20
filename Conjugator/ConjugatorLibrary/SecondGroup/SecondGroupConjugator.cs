using System;
using ConjugatorLibrary.Conjugators;

namespace ConjugatorLibrary.SecondGroup
{
    public class SecondGroupConjugator : IConjugator
    {
        public bool IsInGroup(string verb)
        {
            return verb.EndsWith("ir");
        }

        public Func<string, string[]> Conditionel => EmptyConjugator.GetConjugations;
        public Func<string, string[]> Future => EmptyConjugator.GetConjugations;
        public Func<string, string[]> Imparfait => EmptyConjugator.GetConjugations;
        public Func<string, string[]> Imperatif => EmptyConjugator.GetConjugations;
        public Func<string, string[]> ParticipePasse => EmptyConjugator.GetConjugations;
        public Func<string, string[]> ParticipePresent => EmptyConjugator.GetConjugations;
        public Func<string, string[]> PasseSimple => EmptyConjugator.GetConjugations;
        public Func<string, string[]> Present => PresentConjugator.GetConjugations;
        public Func<string, string[]> SubjonctifImparfait => EmptyConjugator.GetConjugations;
        public Func<string, string[]> SubjonctifPresent => EmptyConjugator.GetConjugations;
    }
}