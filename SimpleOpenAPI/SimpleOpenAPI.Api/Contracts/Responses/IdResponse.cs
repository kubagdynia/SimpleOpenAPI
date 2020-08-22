using System;

namespace SimpleOpenAPI.Api.Contracts.Responses
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