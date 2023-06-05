using System.Linq.Expressions;
using Dogs.Application.Contracts.Persistence;
using Dogs.Application.Features.Dogs.Commands.CreateDog;
using Dogs.Domain.Entities;
using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace Dogs.Application.Test.Features.Dogs.Commands;

public class CreateDogCommandValidatorTests
    {
        private readonly CreateDogCommandValidator _validator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public CreateDogCommandValidatorTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _validator = new CreateDogCommandValidator(_mockUnitOfWork.Object);
        }
        
        [Theory]
        [InlineData("Fabio", "Black", 10, 0)]
        [InlineData("Fabio", "Black", 0, 10)]
        [InlineData("Fabio", "Black", -10, 10)]
        [InlineData("Fabio", "Black", 10, -10)]
        [InlineData("Fabio", null, 0, 10)]
        [InlineData(null, null, 0, 10)]
        public void Validate_Should_HaveValidationError_WhenNullZeroOrNegative(string name, string color, int tailLength, int weight)
        {
            // Arrange
            var command = new CreateDogCommand(name, color, tailLength, weight);
            _mockUnitOfWork.Setup(u => u.DogRepository
                    .ExistAsync(It.IsAny<Expression<Func<Dog, bool>>>(), CancellationToken.None))
                .ReturnsAsync(true);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validate_Should_HaveValidationError_WhenNameAlreadyExists()
        {
            // Arrange
            var existingName = "Fido";
            var command = new CreateDogCommand(existingName, "black", 10, 10);
            _mockUnitOfWork.Setup( u=> u.DogRepository
                    .ExistAsync(c => c.Name == existingName, CancellationToken.None))
                .ReturnsAsync(true);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
    }