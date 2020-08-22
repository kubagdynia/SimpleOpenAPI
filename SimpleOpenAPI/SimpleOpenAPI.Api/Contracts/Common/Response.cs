using System.Text.Json;
using SimpleOpenAPI.Api.Serializers;

namespace SimpleOpenAPI.Api.Contracts.Common
{
    public abstract class Response<T>
    {
        public T Result { get; }

        public Response(T result)
        {
            Result = result;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this, BaseJsonOptions.GetJsonSerializerOptions);
    }
}