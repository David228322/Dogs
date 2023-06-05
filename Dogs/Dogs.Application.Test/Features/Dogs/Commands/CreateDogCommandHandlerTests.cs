using AutoMapper;
using Dogs.Application.Contracts.Persistence;
using Dogs.Application.Features.Dogs.Commands.CreateDog;
using Dogs.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace Dogs.Application.Test.Features.Dogs.Commands;

public class CreateDogCommandHandlerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Dog _dog;
    private readonly CreateDogCommandHandler _handler;


    public CreateDogCommandHandlerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateDogCommandHandler(_mockMapper.Object, _mockUnitOfWork.Object);
        _dog = new Dog()
        {
            Id = 1,
            Name = "Fido",
            Color = "Brown",
            TailLength = 5,
            Weight = 10
        };
    }

    [Fact]
    public async Task Handle_Should_ReturnsDogId()
    {
        // Arrange
        var command = new CreateDogCommand("Fido", "Brown", 5, 10);
        var dog = _dog;
        
        _mockMapper.Setup(m => m.Map<Dog>(command)).Returns(dog);
        _mockUnitOfWork.Setup(u => u.DogRepository.AddAsync(dog)).ReturnsAsync(1);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(1);
    }
}