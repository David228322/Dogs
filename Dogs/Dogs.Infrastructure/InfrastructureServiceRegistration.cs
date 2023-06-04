using Dogs.Application.Contracts.Persistence;
using Dogs.Infrastructure.Persistence;
using Dogs.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dogs.Infrastructure;

/// <summary>
/// Extension method to add infrastructure services to the IServiceCollection.
/// </summary>
public static class InfrastructureServiceRegistration
{
    /// <summary>
    /// Adds infrastructure services to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the services to.</param>
    /// <param name="configuration">The IConfiguration containing the connection string.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DogConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IDogRepository, DogRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
