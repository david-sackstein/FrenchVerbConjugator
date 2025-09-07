using System.Text.Json.Serialization;

namespace ConjugatorLibrary;

public class Verbs
{
    [JsonPropertyName("first_group")] public string[] FirstGroup { get; set; }

    [JsonPropertyName("second_group")] public string[] SecondGroup { get; set; }

    [JsonPropertyName("third_group")] public string[] ThirdGroup { get; set; }
}