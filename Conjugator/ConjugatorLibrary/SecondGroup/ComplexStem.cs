namespace ConjugatorLibrary.SecondGroup
{
    class ComplexStem
    {
        public string NonNousVousStem { get; }
        public string NousVousStem { get; }

        public ComplexStem(string nonNousVousStem, string nousVousStem)
        {
            NonNousVousStem = nonNousVousStem;
            NousVousStem = nousVousStem;
        }
    }
}