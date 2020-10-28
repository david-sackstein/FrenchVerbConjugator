namespace ConjugatorLibrary.FirstGroup
{
    public static class ParticipePresentConjugator
    {
        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);
            return new[] {stem + "ant"};
        }

        private static string GetStem(string verb)
        {
            string stem = verb.Remove(verb.Length - 2);
            if (verb[^3] == 'g')
            {
                return stem + "e";
            }

            if (verb[^3] == 'c')
            {
                return stem.ReplaceAt(-1, 'ç');
            }

            return stem;
        }
    }
}