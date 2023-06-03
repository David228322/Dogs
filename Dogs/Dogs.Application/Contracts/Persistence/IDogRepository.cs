using Dogs.Application.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Domain.Entities;

namespace Dogs.Application.Contracts.Persistence
{
    /// <summary>
    /// Represents a repository for managing dog entities.
    /// </summary>
    public interface IDogRepository
    {
        /// <summary>
        /// Retrieves a list of dogs based on the provided pagination and sort filters.
        /// </summary>
        /// <param name="filter">The pagination filter to apply.</param>
        /// <param name="sortFilter">The sort filter to apply.</param>
        /// <returns>An asynchronous operation that yields the list of dogs.</returns>
        Task<IEnumerable<Dog>> GetDogsByFilterAsync(PaginationFilter filter, SortFilter sortFilter);

        /// <summary>
        /// Creates a new dog based on the provided dog data.
        /// </summary>
        /// <param name="request">The dog data for the creation.</param>
        /// <returns>An asynchronous operation that yields the identifier of the created dog.</returns>
        Task<int> CreateNewDog(DogDto request);
    }
}
