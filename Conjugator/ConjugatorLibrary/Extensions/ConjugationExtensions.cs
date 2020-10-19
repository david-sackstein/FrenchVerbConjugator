using System;
using System.Linq;

namespace ConjugatorLibrary
{
    public static class ConjugationExtensions
    {
        public static string[] MatchNousVous(
            this string[] conjugations, Func<string, string> forNousVous, Func<string, string> forNonNousVous)
        {
            return conjugations
                .Select((s, i) => IsNousVous(i)
                    ? forNousVous(s)
                    : forNonNousVous(s))
                .ToArray();
        }
        
        public static string[] AddEndings(this string stem, string[] endings)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }


        public static string[] MatchNousVous(
            this string[] conjugations, Func<string, string> forNonNousVous)
        {
            return conjugations.MatchNousVous(s => s, forNonNousVous);
        }

        private static bool IsNousVous(int index)
        {
            return index == 3 || index == 4;
        }
    }
}