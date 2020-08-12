using System.Text.Json;

namespace SilverCarnival.Api.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions;

        static JsonExtensions()
        {
            JsonSerializerOptions = new JsonSerializerOptions {WriteIndented = true, PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        }
        
        public static string Serialize<T>(this T o)
        {
            return JsonSerializer.Serialize(o, JsonSerializerOptions);
        }
        
        public static T Deserialize<T>(this string s)
        {
            return JsonSerializer.Deserialize<T>(s, JsonSerializerOptions);
        }
    }
}