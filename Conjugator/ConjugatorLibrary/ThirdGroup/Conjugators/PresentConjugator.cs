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

            // soften the g before an 'o' by adding an e
            string nousEnding = "ons";
            if (verb[^3] == 'g')
            {
                nousEnding = "e" + nousEnding;
            }

            string[] endings = {"e", "es", "e", nousEnding, "ez", "ent"};
            string[] withEndings = ApplyEndings(endings, verb);

            // soften the c with a cedilla before an 'o' for nous (at index 3)
            if (verb[^3] == 'c')
            {
                withEndings[3] = withEndings[3].ReplaceAt(-4, 'ç');
            }

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