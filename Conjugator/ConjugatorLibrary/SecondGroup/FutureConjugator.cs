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
                case "messeoir":
                case "seoir":
                    return verb.ReplaceEnd("seoir", "siér");
                case "voir":
                    return "verr";
            }

            (string verbEnding, string stem)[] stemTuples = {
                ("pouvoir", "pourr"),
                ("vouloir", "voudr"),
                ("pleuvoir", "pleuvr"),
                ("falloir", "faudr"),
                ("avoir", "aur"),
                ("mouvoir", "mouvr"),
                ("asseoir", "assoir"),
                ("valoir", "vaudr"),
                ("revoir", "reverr"),
                ("quérir", "querr"),
                ("evoir", "evr"),
                ("venir", "viendr"),
                ("tenir", "tiendr"),
                ("cevoir", "cevr"),
                ("ourir", "ourr"),
                ("cueillir", "cueiller")
            };

            foreach(var tuple in stemTuples)
            {
                if (verb.EndsWith(tuple.verbEnding))
                {
                    return verb.ReplaceEnd(tuple.verbEnding, tuple.stem);
                }
            }

            return verb;
        }
    }
}