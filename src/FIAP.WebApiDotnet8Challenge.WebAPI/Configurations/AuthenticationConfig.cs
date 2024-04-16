using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Configurations;

internal static class AuthenticationConfig
{
    internal static void AddAuthentication(this IServiceCollection services)
    {
        var tokenKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("TOKEN_SECRET_KEY")
                                               ?? throw new Exception($"TOKEN_SECRET_KEY environment variable not found."));

        services.AddAuthentication(configureOptions =>
            {
                configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }
}