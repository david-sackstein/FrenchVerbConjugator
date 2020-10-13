using System.IO;
using System.Text.Json;

namespace ConjugatorTests
{
    static class ErrorList
    {
        private const string errorFileName = @"..\..\..\errors.txt";

        public static void Save(string[] errorVerbs)
        {
            var errors = JsonSerializer.Serialize(errorVerbs, new JsonSerializerOptions
            {
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
