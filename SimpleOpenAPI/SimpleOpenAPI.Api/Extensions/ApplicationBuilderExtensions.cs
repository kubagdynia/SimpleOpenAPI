using Microsoft.AspNetCore.Builder;

namespace SimpleOpenAPI.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomSwagger(this IApplicationBuilder app, string url = "/swagger/v1/swagger.json", string name = "API V1")
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: url, name: name);
            });
        }
    }
}