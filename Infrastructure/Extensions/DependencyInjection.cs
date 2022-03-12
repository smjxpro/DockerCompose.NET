using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProdInfrastructure(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        services.AddDbContext<TodoDbContext>(options => { options.UseNpgsql(connectionString); });


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddDevInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TodoDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Postgres");
            options.UseNpgsql(connectionString);
        });


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}