using System;

namespace SimpleOpenAPI.Api.Contracts.Responses
{
    public class AddBookResponse : BaseBookResponse
    {
        public AddBookResponse(IdResponse result) : base(result)
        {
            
        }

        public AddBookResponse(Guid id) : base(id)
        {
            
        }
    }
}