namespace ConjugatorLibrary.SecondGroup
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
            return verb;
            //switch (verb)
            //{
            //    case "aller":
            //        return "ir";
            //    case "renvoyer":
            //    case "envoyer":
            //        return verb.Replace("voyer", "verr");
            //    default:
            //        return GetShortenedStem(verb) + "ir";
            //}
        }

        private static string GetShortenedStem(string verb)
        {
            string shortenedStem = verb[..^2];

           
            return shortenedStem;
        }
    }
}