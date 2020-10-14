using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ConjugatorTests
{
    static class ErrorList
    {
        private const string errorFileName = @"..\..\..\errors.txt";

        public static void Save(string[] errorVerbs)
        {
            var errors = JsonSerializer.Serialize(errorVerbs, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            });
            File.WriteAllText(errorFileName, errors);
        }

        public static string[] Load()
        {
            var text = File.ReadAllText(errorFileName);
            return JsonSerializer.Deserialize<string[]>(text);
        }
    }
}
