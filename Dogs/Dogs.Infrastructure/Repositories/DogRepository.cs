using Dogs.Application.Contracts.Persistence;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Application.Models.Filters;
using Dogs.Domain.Entities;
using Dogs.Infrastructure.Persistence;

namespace Dogs.Infrastructure.Repositories;


/// <summary>
/// <see cref="IDogRepository"/>
/// </summary>
public class DogRepository : GenericRepository<Dog>, IDogRepository
{
    /// <inheritdoc />
    public DogRepository(DogContext dogContext) : base(dogContext)
    {
    }
}