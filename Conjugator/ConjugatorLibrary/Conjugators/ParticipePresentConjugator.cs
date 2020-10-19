namespace ConjugatorLibrary
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
            return verb.Remove(verb.Length - 2);
        }
    }
}