using FIAP.WebApiDotnet8Challenge.Application;
using FIAP.WebApiDotnet8Challenge.Repositories.Repositories;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.IoC;

public static class DependenciesInjections
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}