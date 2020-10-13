using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ConjugatorLibrary
{
    public class Conjugator
    {
        public string[] GetErPresent(string verb)
        {
            Contract.Requires(verb.EndsWith("er"));
            Contract.Requires(verb.Length > 2);

            // for manger
            string onsEnding = "ons";
            if (verb[^3] == 'g')
            {
                // soften the g before an 'o'
                onsEnding = "e" + onsEnding;
            }

            string[] endings = {"e", "es", "e", onsEnding, "ez", "ent"};
            string[] withEndings = Apply(endings, verb);

            if (verb[^3] == 'c')
            {
                // soften the c with a cedilla before an 'o'
                withEndings[3] = ReplaceAt(withEndings[3], -4, 'ç');
            }

            return withEndings;
        }

        private static readonly string[] noDoubleL = {
            "celer",
            "ciseler",
            "congeler",
            "courrieler",
            "déceler",
            "décongeler",
            "dégeler",
            "démanteler",
            "dépuceler",
            "geler",
            "greneler",
            "harceler",
            "marteler",
            "modeler",
            "nickeler",
            "peler",
            "receler",
            "regeler",
            "remodeler",
            "surgeler",
            "écarteler"};

        private static readonly string[] noDoubleT = {
            "acheter",
            "becqueter",
            "corseter",
            "craqueter",
            "crocheter",
            "décliqueter",
            "dépaqueter",
            "empaqueter",
            "fureter",
            "guillemeter",
            "haleter",
            "piqueter",
            "préacheter",
            "racheter",
            "rempaqueter"
        };

        private static string[] Apply(string[] endings, string verb)
        {
            string stem = verb.Remove(verb.Length - 2);

            // for précéder (but not planchéier)
            if (verb[^3] != 'i')
            {
                int replacedCharIndex1 = verb.Length - 4;
                if (replacedCharIndex1 > 0 && stem[replacedCharIndex1] == 'é')
                {
                    string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex1, 'è');
                    return new[]
                    {
                        stemJeTuIlIls + endings[0],
                        stemJeTuIlIls + endings[1],
                        stemJeTuIlIls + endings[2],
                        stem + endings[3],
                        stem + endings[4],
                        stemJeTuIlIls + endings[5],
                    };
                }
            }

            if (verb == "achever")
            {
                Console.WriteLine();
            }
            // for acheter but not annexer
            if (! new[] {'x', 'f', 'w', 'y'}.Contains(verb[^3]))
            {
                int replacedCharIndex = verb.Length - 4;
                if (replacedCharIndex > 0 && stem[replacedCharIndex] == 'e')
                {
                    if (stem[replacedCharIndex + 1] == 'l')
                    {
                        if (!noDoubleL.Contains(verb))
                        {
                            // celer
                            string stemJeTuIlIls1 = stem + 'l';
                            return new[]
                            {
                                stemJeTuIlIls1 + endings[0],
                                stemJeTuIlIls1 + endings[1],
                                stemJeTuIlIls1 + endings[2],
                                stem + endings[3],
                                stem + endings[4],
                                stemJeTuIlIls1 + endings[5],
                            };
                        }
                        else
                        {
                            // agneler
                            string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex, 'è');
                            return new[]
                            {
                                stemJeTuIlIls + endings[0],
                                stemJeTuIlIls + endings[1],
                                stemJeTuIlIls + endings[2],
                                stem + endings[3],
                                stem + endings[4],
                                stemJeTuIlIls + endings[5],
                            };
                        }
                    }
                    else if (stem[replacedCharIndex + 1] == 't')
                    {
                        if (!noDoubleT.Contains(verb))
                        {
                            // feuilleter
                            string stemJeTuIlIls1 = stem + 't';
                            return new[]
                            {
                                stemJeTuIlIls1 + endings[0],
                                stemJeTuIlIls1 + endings[1],
                                stemJeTuIlIls1 + endings[2],
                                stem + endings[3],
                                stem + endings[4],
                                stemJeTuIlIls1 + endings[5],
                            };
                        }
                        else
                        {
                            // acheter
                            string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex, 'è');
                            return new[]
                            {
                                stemJeTuIlIls + endings[0],
                                stemJeTuIlIls + endings[1],
                                stemJeTuIlIls + endings[2],
                                stem + endings[3],
                                stem + endings[4],
                                stemJeTuIlIls + endings[5],
                            };
                        }
                    }
                }
            }

            // for aboyer
            int replacedCharIndex2 = verb.Length - 3;
            if (replacedCharIndex2 > 0 && 
                (replacedCharIndex2 + 1 <= stem.Length) && stem.Substring(replacedCharIndex2-1, 2) == "oy")
            {
                string stemJeTuIlIls = ReplaceAt(stem, replacedCharIndex2, 'i');
                return new[]
                {
                    stemJeTuIlIls + endings[0],
                    stemJeTuIlIls + endings[1],
                    stemJeTuIlIls + endings[2],
                    stem + endings[3],
                    stem + endings[4],
                    stemJeTuIlIls + endings[5],
                };
            }

            return endings.Select(ending => stem + ending).ToArray();
        }

        private static string ReplaceAt(string inString, int index, char c)
        {
            int actualIndex = index > 0 ? index : inString.Length + index;
            return new StringBuilder(inString) {[actualIndex] = c}.ToString();
        }
    }
}