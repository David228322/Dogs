using Dogs.Domain.Common;
using Dogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Infrastructure.Persistence;

/// <summary>
/// Represents the database context for managing dog entities.
/// </summary>
public class DogContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DogContext"/> class.
    /// </summary>
    /// <param name="options">The options for configuring the context.</param>
    public DogContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the collection of dog entities.
    /// </summary>
    public DbSet<Dog> Dogs { get;set; }

    /// <summary>
    /// Saves the changes made in this context to the underlying database.
    /// Automatically sets the date created and date updated properties for entities inheriting from <see cref="BaseEntity"/>.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, returning the number of affected rows.</returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.DateUpdated = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}