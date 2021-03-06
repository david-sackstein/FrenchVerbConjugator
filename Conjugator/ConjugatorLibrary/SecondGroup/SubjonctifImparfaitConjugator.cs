﻿namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifImparfaitConjugator
    {
        private static readonly string[] isEndings = {"isse", "isses", "ît", "issions", "issiez", "issent"};
        private static readonly string[] usEndings = {"usse", "usses", "ût", "ussions", "ussiez", "ussent"};

        private static readonly PasseSimpleSubjectifImparfaitConjugatorImpl impl = new PasseSimpleSubjectifImparfaitConjugatorImpl(isEndings, usEndings);

        public static string[] GetConjugations(string verb)
        {
            if (verb == "pleuvoir")
            {
                return new[] {"", "", "plût", "", "", ""};
            }

            return impl.GetConjugations(verb);
        }
    }
}