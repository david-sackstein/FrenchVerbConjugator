namespace ConjugatorLibrary.FirstGroup
{
    public static class FutureConjugator
    {
        public static string[] Endings { get; } = {"ai", "as", "a", "ons", "ez", "ont"};

        public static string[] GetConjugations(string verb)
        {
            string stem = GetStem(verb);

            return Endings.AddEndings(stem);
        }

        public static string GetStem(string verb)
        {
            switch (verb)
            {
                case "aller":
                    return "ir";
                case "renvoyer":
                case "envoyer":
                    return verb.Replace("voyer", "verr");
                default:
                    return GetShortenedStem(verb) + "er";
            }
        }

        private static string GetShortenedStem(string verb)
        {
            string shortenedStem = verb[..^2];

            if (FutureStemModifier.GetModifiedStem(shortenedStem, out string modifiedStem))
            {
                return modifiedStem;
            }

            return shortenedStem;
        }
    }
}