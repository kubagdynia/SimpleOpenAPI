using System;
using SimpleOpenAPI.Api.Contracts.V1.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace SimpleOpenAPI.Api.SwaggerExamples
{
    public class UpdateBookRequestExample : IExamplesProvider<UpdateBookRequest>
    {
        public UpdateBookRequest GetExamples()
        {
            UpdateBookRequest request = new UpdateBookRequest
            {
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

            return request;
        }
    }
}