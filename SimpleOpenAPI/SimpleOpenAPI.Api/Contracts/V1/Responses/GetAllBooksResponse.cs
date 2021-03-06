using System.Collections.Generic;
using SimpleOpenAPI.Api.Contracts.Common;
using SimpleOpenAPI.Api.Contracts.V1.Resources;

namespace SimpleOpenAPI.Api.Contracts.V1.Responses
{
    public class GetAllBooksResponse : Response<IEnumerable<BookResource>>
    {
        public GetAllBooksResponse(IEnumerable<BookResource> result) : base(result)
        {
            
        }
    }
}