using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public static class SubjonctifImparfaitConjugator
    {
        private static readonly string[] Endings = {"asse", "asses", "ât", "assions", "assiez", "assent"};

        public static string[] GetConjugations(string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            // soften the c with a cedilla before the 'a'
            if (verb[^3] == 'c')
            {
                stem = stem.ReplaceAt(-1, 'ç');
            }

            string[] endings = Endings;
            // soften the g before the 'a' by adding an e
            if (verb[^3] == 'g')
            {
                endings = Endings.Select(ending => "e" + ending).ToArray();
            }

            return endings.AddEndings(stem);
        }
    }
}