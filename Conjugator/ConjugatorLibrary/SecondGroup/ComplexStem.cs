namespace ConjugatorLibrary.SecondGroup;

public record ComplexStem(string NonNousVousStem, string NousVousStem);

public record ConjugationParts(string Stem, string[] Endings)
{
    public string[] GetConjugation()
    {
        return Endings.AddEndings(Stem);
    }
}