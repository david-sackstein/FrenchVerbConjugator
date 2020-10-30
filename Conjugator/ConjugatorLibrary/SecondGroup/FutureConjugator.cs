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
                    return verb.ReplaceEnd("seoir", "siér");
                case "pouvoir":
                    return "pourr";
                case "voir":
                    return "verr";
            }

            if (verb.EndsWith("avoir"))
            {
                return verb.ReplaceEnd("avoir", "aur");
            }

            if (verb.EndsWith("mouvoir"))
            {
                return verb.ReplaceEnd("mouvoir", "mouvr");
            }

            if (verb.EndsWith("asseoir"))
            {
                return verb.ReplaceEnd("asseoir", "assoir");
            }

            if (verb.EndsWith("valoir"))
            {
                return verb.ReplaceEnd("valoir", "vaudr");
            }

            if (verb.EndsWith("revoir"))
            {
                return verb.ReplaceEnd("revoir", "reverr");
            }

            if (verb.EndsWith("quérir"))
            {
                return verb.ReplaceEnd("quérir", "querr");
            }

            if (verb.EndsWith("evoir"))
            {
                return verb.ReplaceEnd("evoir", "evr");
            }

            if (verb.EndsWith("venir"))
            {
                return verb.ReplaceEnd("venir", "viendr");
            }

            if (verb.EndsWith("tenir"))
            {
                return verb.ReplaceEnd("tenir", "tiendr");
            }

            if (verb.EndsWith("ourir"))
            {
                return verb.ReplaceEnd("ir", "r");
            }

            if (verb.EndsWith("cueillir"))
            {
                return verb.ReplaceEnd("ir", "er");
            }

            if (verb.EndsWith("cevoir"))
            {
                return verb.ReplaceEnd("cevoir", "cevr");
            }

            return verb;
        }
    }
}