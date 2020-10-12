using System.Diagnostics.Contracts;

namespace ConjugatorLibrary
{
    public class Conjugator
    {
        public string[] GetErPresent(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));

            string stem = verb.Remove(verb.Length - 1);
            string je = stem;
            string tu = stem + "s";
            string il = stem;
            string nous = stem + "ons";
            string vous = stem + "z";
            string ils = stem + "nt";

            return new[]
            {
                je, tu, il, nous, vous, ils
            };
        }
    }
}
