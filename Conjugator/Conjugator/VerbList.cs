using System.Text.Json.Serialization;

namespace Conjugator
{
    public class VerbList
    {
        [JsonPropertyName("verbs")]
        public Verbs Verbs { get; set; }
    }
}