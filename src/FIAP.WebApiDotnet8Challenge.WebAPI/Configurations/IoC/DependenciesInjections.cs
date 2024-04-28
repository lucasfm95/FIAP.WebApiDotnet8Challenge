using FIAP.WebApiDotnet8Challenge.Application.ProductUseCase;
using FIAP.WebApiDotnet8Challenge.Application.Token;
using FIAP.WebApiDotnet8Challenge.Application.UserUseCase;
using FIAP.WebApiDotnet8Challenge.Repositories.Repositories;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Configurations.IoC;

public static class DependenciesInjections
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IProductService, ProductService>();
    }
}