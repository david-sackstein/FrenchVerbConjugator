using System;
using System.Linq;

namespace ConjugatorLibrary
{
    public static class ConjugationExtensions
    {
        public static string[] ForNonNousVous(this string[] conjugations, Func<string, string> others)
        {
            return conjugations
                .Select((s, i) => IsNousVous(i)
                    ? s
                    : others(s))
                .ToArray();
        }

        private static bool IsNousVous(int index)
        {
            return index == 3 || index == 4;
        }
    }
}