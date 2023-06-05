using AutoMapper;
using Dogs.Application.Contracts.Persistence;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Domain.Entities;
using MediatR;

namespace Dogs.Application.Features.Dogs.Commands.CreateDog;

/// <summary>
/// Handler for the <see cref="CreateDogCommand"/> command.
/// </summary>
public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDogCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper">The <see cref="IMapper"/></param>
    /// <param name="unitOfWork">The <see cref="IUnitOfWork"/></param>
    public CreateDogCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<int> Handle(CreateDogCommand request, CancellationToken cancellationToken)
    {
        var newDog = _mapper.Map<Dog>(request);
        var dogId = await _unitOfWork.DogRepository.AddAsync(newDog);
        return dogId;
    }
}
