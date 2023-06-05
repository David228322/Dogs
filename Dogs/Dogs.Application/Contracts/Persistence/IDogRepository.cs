using Dogs.Domain.Entities;

namespace Dogs.Application.Contracts.Persistence
{
    /// <summary>
    /// Represents a repository for managing dog entities.
    /// </summary>
    public interface IDogRepository : IGenericRepository<Dog>
    {
    }
}
