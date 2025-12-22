namespace Taleria.Extensions;

public static class JsonExtensions
{
    private static readonly JsonSerializerOptions IndentedOptions = new()
    {
        WriteIndented = true
    };
    
    extension(string json)
    {
        public string AsIndentedJson()
        {
            using var doc = JsonDocument.Parse(json);
            return JsonSerializer.Serialize(doc, IndentedOptions);
        }
    }
}