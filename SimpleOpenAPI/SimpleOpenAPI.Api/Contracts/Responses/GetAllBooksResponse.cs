using System.Collections.Generic;
using SimpleOpenAPI.Api.Contracts.Common;
using SimpleOpenAPI.Api.Contracts.Resources;

namespace SimpleOpenAPI.Api.Contracts.Responses
{
    public class GetAllBooksResponse : Response<IEnumerable<BookResource>>
    {
        public GetAllBooksResponse(IEnumerable<BookResource> result) : base(result)
        {
            
        }
    }
}