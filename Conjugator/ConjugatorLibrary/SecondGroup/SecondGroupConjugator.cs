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

        public Func<string, string[]> Conditionel => ConditionelConjugator.GetConjugations;
        public Func<string, string[]> Future => FutureConjugator.GetConjugations;
        public Func<string, string[]> Imparfait => ImparfaitConjugator.GetConjugations;
        public Func<string, string[]> Imperatif => EmptyConjugator.GetConjugations;
        public Func<string, string[]> ParticipePasse => ParticipePasseConjugator.GetConjugations;
        public Func<string, string[]> ParticipePresent => ParticipePresentConjugator.GetConjugations;
        public Func<string, string[]> PasseSimple => EmptyConjugator.GetConjugations;
        public Func<string, string[]> Present => PresentConjugator.GetConjugations;
        public Func<string, string[]> SubjonctifImparfait => EmptyConjugator.GetConjugations;
        public Func<string, string[]> SubjonctifPresent => EmptyConjugator.GetConjugations;
    }
}