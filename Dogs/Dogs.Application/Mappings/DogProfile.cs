using AutoMapper;
using Dogs.Application.Features.Dogs.Commands.CreateDog;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Domain.Entities;

namespace Dogs.Application.Mappings;

/// <summary>
/// AutoMapper profile for mapping between Dog and DogDto.
/// </summary>
public class DogProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DogProfile"/> class.
    /// </summary>
    public DogProfile()
    {
        CreateMap<Dog, DogDto>().ReverseMap();
        CreateMap<Dog, CreateDogCommand>().ReverseMap();
    }
}
