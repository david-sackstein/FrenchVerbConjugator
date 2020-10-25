using System;

namespace ConjugatorLibrary.SecondGroup
{
    internal static class ImparfaitConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            if (verb == "falloir")
            {
                return new[] { "", "", "fallait", "", "", "" };
            }

            if (verb == "pleuvoir")
            {
                return new[] { "", "", "pleuvait", "", "", "pleuvaient" };
            }

            if (verb == "seoir")
            {
                return new[] { "", "", "seyait", "", "", "seyaient" };
            }

            if (verb == "messeoir")
            {
                return new[] { "", "", "messeyait", "", "", "messeyaient" };
            }

            if (verb == "chaloir")
            {
                return new string[6];
            }

            var endings = new[] {"ais", "ais", "ait", "ions", "iez", "aient"};
            
            var present = PresentConjugator.GetConjugations(verb);
            var nousForm = present[3];
            var stem = nousForm.TrimEnd("ons");
            return endings.AddEndings(stem);
        }
    }
}