namespace ConjugatorLibrary.SecondGroup
{
    public static class FutureConjugator
    {
        public static string[] Endings { get; } = {"ai", "as", "a", "ons", "ez", "ont"};

        public static string[] GetConjugations(string verb)
        {
            var stem = GetStem(verb);
            return Endings.AddEndings(stem);
        }

        private static string GetStem(string verb)
        {
            switch (verb)
            {
                case "falloir":
                    return "faudr";
                case "pleuvoir":
                    return "pleuvr";
                case "vouloir":
                    return "voudr";
                case "messeoir":
                case "seoir":
                    return verb.TrimEnd("seoir") + "siér";
                case "pouvoir":
                    return "pourr";
                case "voir":
                    return "verr";
            }

            if (verb.EndsWith("avoir"))
            {
                return verb.TrimEnd("avoir") + "aur";
            }

            if (verb.EndsWith("mouvoir"))
            {
                return verb.TrimEnd("mouvoir") + "mouvr";
            }

            if (verb.EndsWith("asseoir"))
            {
                return verb.TrimEnd("asseoir") + "assoir";
            }

            if (verb.EndsWith("valoir"))
            {
                return verb.TrimEnd("valoir") + "vaudr";
            }

            if (verb.EndsWith("revoir"))
            {
                return verb.TrimEnd("revoir") + "reverr";
            }

            if (verb.EndsWith("quérir"))
            {
                return verb.TrimEnd("quérir") + "querr";
            }

            if (verb.EndsWith("evoir"))
            {
                return verb.TrimEnd("evoir") + "evr";
            }

            if (verb.EndsWith("venir"))
            {
                return verb.TrimEnd("venir") + "viendr";
            }

            if (verb.EndsWith("tenir"))
            {
                return verb.TrimEnd("tenir") + "tiendr";
            }

            if (verb.EndsWith("ourir"))
            {
                return verb.TrimEnd("ir") + "r";
            }

            if (verb.EndsWith("cueillir"))
            {
                return verb.TrimEnd("ir") + "er";
            }

            if (verb.EndsWith("cevoir"))
            {
                return verb.TrimEnd("cevoir") + "cevr";
            }

            return verb;
        }
    }
}