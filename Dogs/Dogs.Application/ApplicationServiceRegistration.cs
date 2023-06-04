using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Dogs.Application;

/// <summary>
/// Provides extension methods to register application services.
/// </summary>
public static class ApplicationServiceRegistration
{
    /// <summary>
    /// Registers application services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}