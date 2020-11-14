namespace ConjugatorLibrary.ThirdGroup
{
    public static class PresentConjugator
    {
        private static readonly string[] endings = new string[] {"s", "s", "t", "ons", "ez", "ent"};
        
        public static string[] GetConjugations(string verb)
        {
            if (verb == "suivre")
            {
                return new[] {"suis", "suis", "suit", "suivons", "suivez", "suivent"};
            }

            string stem = verb.TrimEnd("re");
            var withEndings = endings.AddEndings(stem);
            return withEndings;
        }

        private static string[] ApplyEndings(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            // determine the stem for je, tu, il, ils ("modifiedStem") which may
            // not be the same as for nous and vous

            return endings.AddEndings(stem);
        }
    }
}