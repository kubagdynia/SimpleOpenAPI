using System;

namespace SimpleOpenAPI.Api.Contracts.V1.Responses
{
    public class UpdateBookResponse : BaseBookResponse
    {
        public UpdateBookResponse(IdResponse result) : base(result)
        {
            
        }

        public UpdateBookResponse(Guid id) : base(id)
        {
            
        }
    }
}