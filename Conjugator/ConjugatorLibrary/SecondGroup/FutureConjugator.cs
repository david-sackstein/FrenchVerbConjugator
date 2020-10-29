namespace ConjugatorLibrary.SecondGroup
{
    public static class FutureConjugator
    {
        public static string[] Endings { get; } = {"ai", "as", "a", "ons", "ez", "ont"};

        public static string[] GetConjugations(string verb)
        {
            if (verb.EndsWith("tenir"))
            {
                string stem = verb.TrimEnd("tenir") + "tiendr";
                return Endings.AddEndings(stem);

            }
            string regularStem = GetStem(verb);

            return Endings.AddEndings(regularStem);
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