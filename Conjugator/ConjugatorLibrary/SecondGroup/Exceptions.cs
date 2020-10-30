using System.Linq;

namespace ConjugatorLibrary.SecondGroup
{
    static class Exceptions
    {
        public static readonly string[] verbsWithSstEndings =
        {
            "départir", "repartir", "partir", "repentir", 
            "sortir", "consentir", "desservir", "dormir", "démentir", 
            "endormir", "mentir", "pressentir", "redormir", 
            "rendormir", "ressentir", "resservir", "sentir", "servir"
        };

        public static readonly string[] verbsWithErtEndings = {
            "offrir", "souffrir",
            "couvrir", "découvrir", "entrouvrir", "ouvrir", 
            "recouvrir", "redécouvrir", "rouvrir", "réouvrir",
        };

        public static readonly string[] verbsWithErEndings = verbsWithErtEndings.Concat(new[]
        {
            "accueillir", "assaillir", "recueillir", "cueillir", 
            "défaillir", "tressaillir"
        }).ToArray();

        public static readonly string[] verbsWithYonsEndings =
        {
            "choir", "déchoir", "dépourvoir", "entrevoir", 
            "pourvoir", "prévoir", "ravoir", "revoir",
            "voir", "échoir", "enfuir", "fuir"
        };

        public static readonly string[] cevoirVerbs =
        {
            "apercevoir", "concevoir", "décevoir", "entrapercevoir", 
            "percevoir", "préconcevoir", "recevoir"
        };

        public static readonly string[] devoirVerbs =
        {
            "devoir", "redevoir"
        };
    }
}
