using System.Text.Json.Serialization;

namespace ConjugatorLibrary;

public class VerbList
{
    [JsonPropertyName("verbs")]
    public Verbs Verbs { get; set; }
}