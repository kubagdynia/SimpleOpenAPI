using System;
using SimpleOpenAPI.Api.Contracts.V1.Resources;
using SimpleOpenAPI.Api.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace SimpleOpenAPI.Api.SwaggerExamples
{
    public class GetBookResponseExample : IExamplesProvider<GetBookResponse>
    {
        public GetBookResponse GetExamples()
        {
            BookResource bookResource = new BookResource
            {
                Id = Guid.NewGuid().ToString(),
                Title = "ASP.NET Core 3 and Angular 9 - Third Edition",
                PageCount = 732,
                Isbn = "9781789612165",
                PublicationDate = new DateTime(2020, 08, 22, 19, 08, 20),
                AuthorName = "Valerio De Sanctis",
                ShortDescription =
                    "The book will get you started with using the .NET Core framework and Web API Controllers to implement API calls and server-side routing in the backend.",
                Publisher = "Packt",
                Url = "https://www.packtpub.com/product/asp-net-core-3-and-angular-9-third-edition/9781789612165"
            };
            
            var response = new GetBookResponse(bookResource);
            return response;
        }
    }
}