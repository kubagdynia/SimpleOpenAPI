using SimpleOpenAPI.Api.Contracts.Common;
using SimpleOpenAPI.Api.Contracts.V1.Resources;

namespace SimpleOpenAPI.Api.Contracts.V1.Responses
{
    public class GetBookResponse : Response<BookResource>
    {
        public GetBookResponse(BookResource result) : base(result)
        {
            
        }
    }
}