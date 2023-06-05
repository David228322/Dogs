namespace Dogs.Application.Features.Dogs.Queries.GetDogsList
{
    /// <summary>
    /// Represents a dog dto entity.
    /// </summary>
    public class DogDto
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
