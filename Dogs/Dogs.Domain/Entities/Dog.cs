using Dogs.Domain.Common;
namespace Dogs.Domain.Entities
{
    /// <summary>
    /// Represents a dog entity.
    /// </summary>
    public class Dog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the dog.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the color of the dog.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the length of the dog's tail.
        /// </summary>
        public int TailLength { get; set; }

        /// <summary>
        /// Gets or sets the weight of the dog.
        /// </summary>
        public int Weight { get; set; }
    }
}
