using Dogs.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Dogs.Infrastructure.Persistence;

/// <summary>
/// Helper class for seeding the DogContext database.
/// </summary>
public class DogSeedContext
{
    /// <summary>
    /// Seeds the DogContext database with preconfigured data if it is empty.
    /// </summary>
    /// <param name="orderContext">The DogContext instance.</param>
    /// <param name="logger">The logger instance.</param>
    /// <returns>A task representing the asynchronous seeding operation.</returns>
    public static async Task SeedAsync(DogContext orderContext, ILogger<DogSeedContext> logger)
    {
        if (!orderContext.Dogs.Any())
        {
            orderContext.Dogs.AddRange(GetPreconfiguredOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", nameof(DogContext));
        }
    }

    private static IEnumerable<Dog> GetPreconfiguredOrders()
    {
        return new List<Dog>
        {
            new() {Name = "Neo", Color = "red & amber", TailLength = 22, Weight = 32},
            new() {Name = "Jessy", Color = "black & white", TailLength = 7, Weight = 14}
        };
    }
}