using System;
using System.Linq;

namespace ConjugatorLibrary
{
    public static class ConjugationExtensions
    {
        public static string[] AddEndings(
            this string[] endings, string stem)
        {
            return endings.Select(ending => stem + ending).ToArray();
        }

        public static string[] AddEndings(this string[] endings, 
            string nonNousVousStem, 
            string nousVousStem)
        {
            return endings.MatchNousVous(
                e => nonNousVousStem + e, 
                e => nousVousStem + e);
        }

        public static string[] AddEndings(this string[] conjugations, 
            string nonNousVousStem, 
            string nousVousStem, 
            string ilsStem)
        {
            return conjugations.MatchNousVousIls(
                e => nonNousVousStem + e,
                e => nousVousStem + e, 
                e => ilsStem + e);
        }

        public static string[] MatchNousVousIls(this string[] conjugations,
            Func<string, string> forNonNousVous,
            Func<string, string> forNousVous,
            Func<string, string> forIls)
        {
            return conjugations
                .Select((s, i) =>
                {
                    if (IsNousVous(i))
                    {
                        return forNousVous(s);
                    }
                    if (IsIls(i))
                    {
                        return forIls(s);
                    }
                    return forNonNousVous(s);
                })
                .ToArray();
        }

        public static string[] MatchNousVous(
            this string[] conjugations,
            Func<string, string> forNonNousVous,
            Func<string, string> forNousVous)
        {
            return conjugations
                .Select((s, i) => IsNousVous(i)
                    ? forNousVous(s)
                    : forNonNousVous(s))
                .ToArray();
        }

        public static string[] MatchNousVous(
            this string[] conjugations, 
            Func<string, string> forNonNousVous)
        {
            return conjugations.MatchNousVous(forNonNousVous, s => s);
        }

        private static bool IsNousVous(int index)
        {
            return index == 3 || index == 4;
        }

        private static bool IsIls(in int i)
        {
            return i == 5;
        }
    }
}