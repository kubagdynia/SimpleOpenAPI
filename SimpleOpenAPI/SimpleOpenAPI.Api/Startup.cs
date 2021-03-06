using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.OpenApi.Models;
using SimpleOpenAPI.Api.Extensions;
using SimpleOpenAPI.Api.Serializers;
using SimpleOpenAPI.Domain.Repositories;

namespace SimpleOpenAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = BaseJsonOptions.IgnoreNullValues;
                options.JsonSerializerOptions.PropertyNamingPolicy = BaseJsonOptions.PropertyNamingPolicy;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IBookRepository, MemoryBookRepository>();
            
            services.AddSwagger<Startup>(includeXmlComments: true, name: "v1", title: "Book API", version: "v1",
                "API for book management", new OpenApiContact { Email = "apiowner@email.com", Name = "API Owner" });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCustomSwagger("/swagger/v1/swagger.json", "Book API V1");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
