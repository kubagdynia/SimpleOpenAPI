using System;

namespace SimpleOpenAPI.Api.Contracts.V1.Responses
{
    public class IdResponse
    {
        public Guid Id { get; }

        public IdResponse(Guid id)
        {
            Id = id;
        }
    }
}