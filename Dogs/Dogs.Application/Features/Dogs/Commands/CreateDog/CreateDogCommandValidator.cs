using Dogs.Application.Contracts.Persistence;
using FluentValidation;

namespace Dogs.Application.Features.Dogs.Commands.CreateDog;

/// <summary>
/// Validator for the <see cref="CreateDogCommand"/> class.
/// </summary>
public class CreateDogCommandValidator : AbstractValidator<CreateDogCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDogCommandValidator"/> class.
    /// </summary>
    /// <param name="unitOfWork">The <see cref="IUnitOfWork"/></param>
    public CreateDogCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Color).NotEmpty();
        RuleFor(x => x.Weight).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(x => x.TailLength).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(x => x.Name)
            .Must(x => !unitOfWork.DogRepository.ExistAsync(c => c.Name == x).Result)
            .WithMessage("Dog with '{PropertyValue}' name already exists in the database.");
    }
}
