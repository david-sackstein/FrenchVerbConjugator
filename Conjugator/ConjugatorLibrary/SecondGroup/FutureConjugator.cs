namespace ConjugatorLibrary.SecondGroup
{
    public static class FutureConjugator
    {
        public static string[] Endings { get; } = {"ai", "as", "a", "ons", "ez", "ont"};

        public static string[] GetConjugations(string verb)
        {
            if (verb == "falloir")
            {
                string stem = "faudr";
                return Endings.AddEndings(stem);
            }

            if (verb == "pleuvoir")
            {
                string stem = "pleuvr";
                return Endings.AddEndings(stem);
            }

            if (verb == "vouloir")
            {
                string stem = "voudr";
                return Endings.AddEndings(stem);
            }

            if (verb == "messeoir" || verb == "seoir")
            {
                string stem = verb.TrimEnd("seoir") + "siér";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("avoir"))
            {
                string stem = verb.TrimEnd("avoir") + "aur";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("mouvoir"))
            {
                string stem = verb.TrimEnd("mouvoir") + "mouvr";
                return Endings.AddEndings(stem);
            }

            if (verb == "pouvoir")
            {
                string stem = "pourr";
                return Endings.AddEndings(stem);
            }

            if (verb == "voir")
            {
                string stem = "verr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("asseoir"))
            {
                string stem = verb.TrimEnd("asseoir") + "assoir";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("valoir"))
            {
                string stem = verb.TrimEnd("valoir") + "vaudr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("revoir"))
            {
                string stem = verb.TrimEnd("revoir") + "reverr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("quérir"))
            {
                string stem = verb.TrimEnd("quérir") + "querr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("evoir"))
            {
                string stem = verb.TrimEnd("evoir") + "evr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("venir"))
            {
                string stem = verb.TrimEnd("venir") + "viendr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("tenir"))
            {
                string stem = verb.TrimEnd("tenir") + "tiendr";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("ourir"))
            {
                string stem = verb.TrimEnd("ir") + "r";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("cueillir"))
            {
                string stem = verb.TrimEnd("ir") + "er";
                return Endings.AddEndings(stem);
            }

            if (verb.EndsWith("cevoir"))
            {
                string stem = verb.TrimEnd("cevoir") + "cevr";
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