using desafio_back_end_picpay.Repository.ShopKeeperRepository;
using desafio_back_end_picpay.Repository.UserRepository;

namespace desafio_back_end_picpay.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services
            .AddRepositories();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IShopKeeperRepository,ShopkeeperRepository>();

        services
            .AddScoped<IUserRepository,UserRepository>();

        return services;
    }
}
