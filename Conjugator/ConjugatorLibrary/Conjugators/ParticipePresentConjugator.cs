﻿namespace ConjugatorLibrary
{
    public static class ParticipePresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem1(verb);
            return new[] {stem + "ant"};
        }

        private static string GetStem1(string verb)
        {
            string stem = verb.Remove(verb.Length - 2);
            if (verb[^3] == 'g')
            {
                return stem + "e";
            }
            return stem;
        }

        private static string GetStem(string verb)
        {
            return verb.Remove(verb.Length - 2);
        }
    }
}