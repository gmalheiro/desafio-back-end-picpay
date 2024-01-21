using desafio_back_end_picpay.Business;
using desafio_back_end_picpay.Business.TransactionBusiness;
using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace desafio_back_end_picpay.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, string connString)
    {
        services
            .AddRepositories()
            .AddDbContext(connString)
            .AddBusiness();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository,UserRepository>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services,string connString)
    {
        services
            .AddDbContext<DatabaseContext>(options => 
                                            options
                                            .UseSqlServer(connString));

        return services;
    }

    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services
            .AddScoped<IUserBusiness,UserBusiness>()
            .AddScoped<ITransactionBusiness,TransactionBusiness>();

        return services;
    }
}
