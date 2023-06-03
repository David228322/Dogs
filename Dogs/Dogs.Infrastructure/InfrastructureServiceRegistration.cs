using Dogs.Application.Contracts.Persistence;
using Dogs.Infrastructure.Persistence;
using Dogs.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dogs.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DogConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IDogRepository, DogRepository>();
        
        return services;
    }
}