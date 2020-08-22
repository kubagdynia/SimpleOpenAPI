using System.Text.Json;

namespace SimpleOpenAPI.Api.Serializers
{
    public static class BaseJsonOptions
    {
        public static bool IgnoreNullValues { get; } = true;
        
        public static JsonNamingPolicy PropertyNamingPolicy { get; } = JsonNamingPolicy.CamelCase;
        
        public static JsonSerializerOptions GetJsonSerializerOptions { get; } = new JsonSerializerOptions
        {
            IgnoreNullValues = IgnoreNullValues,
            PropertyNamingPolicy = PropertyNamingPolicy,
        };
    }
}