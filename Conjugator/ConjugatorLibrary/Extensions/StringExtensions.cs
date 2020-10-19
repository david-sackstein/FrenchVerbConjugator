using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConjugatorLibrary
{
    public static class StringExtensions
    {
        public static string ReplaceAt(this string inString, int index, char c)
        {
            if (index < 0)
            {
                Console.WriteLine();
            }
            int positiveIndex = index > 0 ? index : inString.Length + index;
            return new StringBuilder(inString) {[positiveIndex] = c}.ToString();
        }

        public static IEnumerable<string> SelectExceptFor(this IEnumerable<string> source, int index, Func<string, string> selector)
        {
            return source.Select((s, i) => i != 5 ? selector(s) : s);
        }
    }
}