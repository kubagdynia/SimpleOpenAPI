using System;
using SimpleOpenAPI.Api.Contracts.Common;

namespace SimpleOpenAPI.Api.Contracts.Responses
{
    public class AddBookResponse : Response<IdResponse>
    {
        public AddBookResponse(IdResponse result) : base(result)
        {
            
        }

        public AddBookResponse(Guid id) : base(new IdResponse(id))
        {
            
        }
    }
}