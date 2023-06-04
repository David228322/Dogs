using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dogs.API.Extensions;

/// <summary>
/// Extension methods for <see cref="IHost"/> for database migration.
/// </summary>
public static class HostExtensions
{
    /// <summary>
    /// Migrates the database associated with the specified context and invokes the seeder action.
    /// </summary>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    /// <param name="host">The host.</param>
    /// <param name="seeder">The action to invoke for seeding the database.</param>
    /// <param name="retry">The maximum number of retries for handling SQL exceptions during migration.</param>
    /// <returns>The host instance.</returns>
    public static IHost MigrateDatabase<TContext>(this IHost host,
                                                 Action<TContext, IServiceProvider> seeder,
                                                 int? retry = 0) where TContext : DbContext
    {
        int retryForAvailability = retry.Value;

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                context.Database.Migrate();
                seeder(context, services);

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    System.Threading.Thread.Sleep(2000);
                    host.MigrateDatabase<TContext>(seeder, retryForAvailability);
                }
            }
        }
        return host;
    }
}
