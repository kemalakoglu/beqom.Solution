using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace beqom.Presentation.API.Extensions
{
    public static class Swagger
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("beqom", new OpenApiInfo
                {
                    Title = "beqom API",
                    Version = "beqom",
                    Description = "beqom Web API Documentation",
                    //Contact = new Contact
                    //{
                    //    Name = "Swagger Implementation of Kemal Akoğlu",
                    //    //Url = "http://doco.com.tr",
                    //    Email = "kemal.akoglu@doco.com.tr"
                    //}
                });
            });
        }
    }
}