﻿using System.Linq;

namespace ConjugatorLibrary
{
    public static class SubjonctifImparfaitConjugator
    {
        private static readonly string[] Endings = { "asse", "asses", "ât", "assions", "assiez", "assent" };

        public static string[] GetConjugations(string verb)
        {
            var stem = verb.Remove(verb.Length - 2);
            
            // soften the c with a cedilla before the 'a'
            if (verb[^3] == 'c')
            {
                stem = stem.ReplaceAt(-1, 'ç');
            }

            var endings = Endings;
            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = Endings.Select(ending => "e" + ending).ToArray();
            }

            return stem.AddEndings(endings);
        }
    }
}