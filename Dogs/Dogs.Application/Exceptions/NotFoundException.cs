namespace Dogs.Application.Exceptions
{
    /// <summary>
    /// Exception thrown when an entity is not found.
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with the specified entity name and key.
        /// </summary>
        /// <param name="name">The name of the entity.</param>
        /// <param name="key">The key of the entity.</param>
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found")
        {
        }
    }
}
