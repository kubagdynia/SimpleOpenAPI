using System;

namespace SimpleOpenAPI.Api.Contracts.Responses
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