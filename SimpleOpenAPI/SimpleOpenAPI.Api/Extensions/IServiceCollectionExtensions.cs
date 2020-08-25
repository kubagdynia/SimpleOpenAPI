using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace SimpleOpenAPI.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger<T>(this IServiceCollection services, bool includeXmlComments = false,
            string name = "v1", string title = "API", string version = "v1", string description = "", OpenApiContact contact = null)
            => AddSwagger<T>(services, typeof(T).Assembly, includeXmlComments, name, title, version, description, contact);
        
        public static IServiceCollection AddSwagger<T>(this IServiceCollection services, Assembly assembly, bool includeXmlComments = false,
            string name = "v1", string title = "API", string version = "v1", string description = "", OpenApiContact contact = null)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: name, new OpenApiInfo
                {
                    Title = title,
                    Version = version,
                    Description = description,
                    Contact = contact
                });
                
                c.IgnoreObsoleteActions();

                if (includeXmlComments)
                {
                    c.ExampleFilters();

                    var xmlFile = $"{assembly.GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    if (File.Exists(xmlPath))
                    {
                        c.IncludeXmlComments(xmlPath);
                    }
                }

            });

            if (includeXmlComments)
            {
                services.AddSwaggerExamplesFromAssemblyOf<T>();
            }

            return services;
        }
    }
}