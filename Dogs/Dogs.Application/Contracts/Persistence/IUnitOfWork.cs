namespace Dogs.Application.Contracts.Persistence;

/// <summary>
/// Represents a unit of work interface.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets or sets the dog repository.
    /// </summary>
    IDogRepository DogRepository { get; set; }
}