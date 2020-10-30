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

            (string, string)[] a = {
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

            foreach(var aa in a)
            {
                if (verb.EndsWith(aa.Item1))
                {
                    return verb.ReplaceEnd(aa.Item1, aa.Item2);
                }
            }

            return verb;
        }
    }
}