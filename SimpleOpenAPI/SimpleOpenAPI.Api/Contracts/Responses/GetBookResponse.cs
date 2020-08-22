using SimpleOpenAPI.Api.Contracts.Common;
using SimpleOpenAPI.Api.Contracts.Resources;

namespace SimpleOpenAPI.Api.Contracts.Responses
{
    public class GetBookResponse : Response<BookResource>
    {
        public GetBookResponse(BookResource result) : base(result)
        {
            
        }
    }
}