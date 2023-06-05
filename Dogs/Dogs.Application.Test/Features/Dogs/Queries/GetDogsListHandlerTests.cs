using AutoMapper;
using Dogs.Application.Contracts.Persistence;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Application.Models.Filters;
using Dogs.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace Dogs.Application.Test.Features.Dogs.Queries;

public class GetDogsListHandlerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly GetDogsListHandler _handler;

    public GetDogsListHandlerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetDogsListHandler(_mockMapper.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnsDogDtos()
    {
        // Arrange
        var query = new GetDogsListQuery(new PaginationFilter(), new SortFilter());
        var dogs = new List<Dog> { new Dog { Id = 1, Name = "Fido" }, new Dog { Id = 2, Name = "Rex" } };
        var dogDtos = new List<DogDto> { new DogDto { Name = "Fido" }, new DogDto { Name = "Rex" } };
        _mockUnitOfWork.Setup(u => u.DogRepository.GetFilteredAsync(query.PaginationFilter, query.SortFilter)).ReturnsAsync(dogs);
        _mockMapper.Setup(m => m.Map<IEnumerable<DogDto>>(dogs)).Returns(dogDtos);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().Equal(dogDtos);
    }
}