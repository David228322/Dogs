using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using MediatR;

namespace Dogs.Application.Features.Dogs.Commands.CreateDog;

/// <summary>
/// Represents a command to create a new dog.
/// </summary>
public class CreateDogCommand : IRequest<int>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDogCommand"/> class.
    /// </summary>
    /// <param name="name">The name of the dog.</param>
    /// <param name="color">The color of the dog.</param>
    /// <param name="tailLength">The length of the dog's tail.</param>
    /// <param name="weight">The weight of the dog.</param>
    public CreateDogCommand(string name, string color, int tailLength, int weight)
    {
        Weight = weight;
        TailLength = tailLength;
        Color = color;
        Name = name;
    }
}
