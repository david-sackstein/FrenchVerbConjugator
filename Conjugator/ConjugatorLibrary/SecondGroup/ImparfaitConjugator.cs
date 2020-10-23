using System;

namespace ConjugatorLibrary.SecondGroup
{
    internal static class ImparfaitConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            var endings = new[] {"ais", "ais", "ait", "ions", "iez", "aient"};
            var present = PresentConjugator.GetConjugations(verb);
            try
            {
                var nousForm = present[3];
                var stem = nousForm.TrimEnd("ons");
                return endings.AddEndings(stem);
            }
            catch (Exception e)
            {
                return present;
            }
        }
    }
}