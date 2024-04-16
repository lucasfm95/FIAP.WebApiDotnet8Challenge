using Microsoft.OpenApi.Models;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Configurations;

internal static class SwaggerConfig
{
    internal static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Product CRUD API", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.Example: Bearer 12345your-token-67890",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }
}