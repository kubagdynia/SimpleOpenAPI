using System;
using SimpleOpenAPI.Api.Contracts.Common;

namespace SimpleOpenAPI.Api.Contracts.V1.Responses
{
    public abstract class BaseBookResponse : Response<IdResponse>
    {
        protected BaseBookResponse(IdResponse result) : base(result)
        {
            
        }

        protected BaseBookResponse(Guid id) : base(new IdResponse(id))
        {
            
        }
    }
}