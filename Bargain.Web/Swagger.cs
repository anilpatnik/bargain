using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Bargain.Web
{
    public static class Swagger
    {
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                // Response Header
                cfg.OperationFilter<AddResponseHeadersFilter>();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);

                // Display auth button and roles
                cfg.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                cfg.OperationFilter<SecurityRequirementsOperationFilter>();

                // JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {                    
                    Description = "Enter Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                };
                cfg.AddSecurityDefinition("oauth2", securityScheme);   
            });            
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                options.DocumentTitle = "API";
            });
        }
    }
}
