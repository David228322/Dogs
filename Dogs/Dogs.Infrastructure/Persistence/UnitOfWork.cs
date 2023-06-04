using Dogs.Application.Contracts.Persistence;

namespace Dogs.Infrastructure.Persistence;

/// <inheritdoc />
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IUnitOfWork"/> class.
    /// </summary>
    /// <param name="dogRepository"><see cref="IDogRepository"/></param>
    public UnitOfWork(IDogRepository dogRepository)
    {
        DogRepository = dogRepository;
    }

    /// <inheritdoc />
    public IDogRepository DogRepository { get; set; }
}