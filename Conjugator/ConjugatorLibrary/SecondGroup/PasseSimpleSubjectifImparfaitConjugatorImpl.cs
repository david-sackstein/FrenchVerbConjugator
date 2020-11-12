using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    public class PasseSimpleSubjectifImparfaitConjugatorImpl
    {
        private readonly string[] _isEndings;
        private readonly string[] _usEndings;

        public PasseSimpleSubjectifImparfaitConjugatorImpl(string[] isEndings, string[] usEndings)
        {
            _isEndings = isEndings;
            _usEndings = usEndings;
        }

        public string[] GetConjugations(string verb)
        {
            if (verb == "avoir")
            {
                return _usEndings.AddEndings("e");
            }

            if (verb == "savoir")
            {
                return _usEndings.AddEndings("s");
            }

            var parts = GetConjugationParts(verb);

            return parts.GetConjugation();
        }

        private ConjugationParts GetConjugationParts(string verb)
        {
            if (verb.EndsWith("ourir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("ir"),
                    _usEndings);
            }

            if (verb.EndsWith("oir"))
            {
                return GetOirConjugationParts(verb);
            }

            if (verb.EndsWith("quérir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("érir"),
                    _isEndings);
            }

            if (verb.EndsWith("enir"))
            {
                var stem = verb.TrimEnd("enir");
                var endings = _isEndings.Select(s => s.Insert(1, "n")).ToArray();
                return new ConjugationParts(stem, endings);
            }

            var regularStem = verb.TrimEnd("ir");
            return new ConjugationParts(regularStem, _isEndings);
        }

        private ConjugationParts GetOirConjugationParts(string verb)
        {
            if (Exceptions.cevoirVerbs.Contains(verb))
            {
                return new ConjugationParts(
                    verb.TrimEnd("cevoir") + "ç",
                    _usEndings);
            }

            if (verb.EndsWith("ouvoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("ouvoir"),
                    _usEndings);
            }

            if (verb.EndsWith("devoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("evoir"),
                    _usEndings);
            }

            if (verb.EndsWith("eoir"))
            {
                return new ConjugationParts(
                    verb.TrimEnd("eoir"),
                    _isEndings);
            }

            var stem = verb.TrimEnd("oir");

            return verb == "revoir" || verb == "entrevoir" || verb == "prévoir" || verb == "voir"
                ? new ConjugationParts(stem, _isEndings)
                : new ConjugationParts(stem, _usEndings);
        }
    }
}