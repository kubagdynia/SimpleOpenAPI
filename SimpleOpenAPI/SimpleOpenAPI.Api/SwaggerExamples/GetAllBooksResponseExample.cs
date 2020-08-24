using System;
using System.Collections.Generic;
using SimpleOpenAPI.Api.Contracts.Resources;
using SimpleOpenAPI.Api.Contracts.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace SimpleOpenAPI.Api.SwaggerExamples
{
    public class GetAllBooksResponseExample : IExamplesProvider<GetAllBooksResponse>
    {
        public GetAllBooksResponse GetExamples()
        {
            IEnumerable<BookResource> bookResources = new List<BookResource>
            {
                GetBookResource(),
                GetBookResource()
            };
            
            var response = new GetAllBooksResponse(bookResources);
            return response;
        }

        private BookResource GetBookResource()
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
            return bookResource;
        }
    }
}