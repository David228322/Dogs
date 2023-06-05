using System.Collections;
using System.Linq.Expressions;
using Dogs.Application.Models.Filters;
using Dogs.Domain.Common;

namespace Dogs.Application.Contracts.Persistence;

/// <summary>
/// Represents a generic repository for managing entities of type T.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IGenericRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Retrieves all entities of type T.
    /// </summary>
    /// <returns>An asynchronous operation that yields the list of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync();
    
    /// <summary>
    /// Retrieves a list of entities based on the provided pagination and sort filters.
    /// </summary>
    /// <param name="paginationFilter"><see cref="PaginationFilter"/></param>
    /// <param name="sortFilter"><see cref="SortFilter"/></param>
    /// <returns>An asynchronous operation that yields the list of entities.</returns>
    Task<IEnumerable<T>> GetFilteredAsync(PaginationFilter paginationFilter, SortFilter sortFilter);

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>An asynchronous operation that yields the entity.</returns>
    Task<T> GetByIdAsync(int id);

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>An asynchronous operation that yields the identifier of the added entity.</returns>
    Task<int> AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>An asynchronous operation.</returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes an existing entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>An asynchronous operation.</returns>
    Task DeleteAsync(T entity);

    /// <summary>
    /// Checks if any entity matching the specified predicate exists in the repository.
    /// </summary>
    /// <param name="predicate">The predicate used to filter entities (optional).</param>
    /// <param name="cancellationToken">The cancellation token (optional).</param>
    /// <returns>True if an entity matching the predicate exists, otherwise false.</returns>
    Task<bool> ExistAsync(
        Expression<Func<T, bool>> predicate = null,
        CancellationToken cancellationToken = default);
}
