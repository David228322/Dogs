using System.ComponentModel.DataAnnotations;
using Dogs.API.Controllers.V1;
using Dogs.Application.Features.Dogs.Commands.CreateDog;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Application.Models;
using Dogs.Application.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Dogs.Application.Exceptions;
using Dogs.Domain.Entities;
using FluentValidation.Results;
using ValidationException = Dogs.Application.Exceptions.ValidationException;

namespace Dogs.API.Test.Controllers.V1;

public class DogControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly DogController _dogController;

        public DogControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _dogController = new DogController(_mediatorMock.Object);
        }

        [Fact]
        public void Ping_Should_ReturnsOkResultWithPingResponse()
        {
            // Act
            var result = _dogController.Ping();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal("Dogs house service. Version 1.0.1", okResult.Value);
        }

        [Fact]
        public async Task GetFilteredDogsList_Should_ReturnsOkResultWithListOfDogs()
        {
            // Arrange
            var paginationFilter = new PaginationFilter { PageNumber = 1, PageSize = 10 };
            var sortFilter = new SortFilter { Attribute = "Name", Order = SortingOrder.Desc };
            var expectedDogs = new List<DogDto> { new() { Name = "Fido" }, new() { Name = "Rex" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDogsListQuery>(), CancellationToken.None)).ReturnsAsync(expectedDogs);

            // Act
            var result = await _dogController.GetFilteredDogsList(paginationFilter, sortFilter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var dogs = Assert.IsType<List<DogDto>>(okResult.Value);
            Assert.Equal(expectedDogs, dogs);
        }


        [Fact]
        public async Task CreateNewDog_Should_ReturnsOkResultWithDogId_WithValidRequest()
        {
            // Arrange
            var createDogCommand = new CreateDogCommand("DogName", "Black", 10, 20);
            var dogId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateDogCommand>(), CancellationToken.None)).ReturnsAsync(dogId);

            // Act
            var result = await _dogController.CreateNewDog(createDogCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(dogId, okResult.Value);
        }

        [Theory]
        [InlineData("", "Black", 10, 20, nameof(Dog.Name), $"{nameof(Dog.Color)} is required")]
        [InlineData("Rex", "", 10, 20, nameof(Dog.Color), $"{nameof(Dog.Color)} is required")]
        public async Task CreateNewDog_Should_WithInvalidRequest_ReturnsBadRequestResultWithErrorResponse_WhenMissingData(
            string name, 
            string color, 
            int tailLength, 
            int weight, 
            string propertyName, 
            string errorMessage)
        {
            // Arrange
            var createDogCommand = new CreateDogCommand(name, color, tailLength, weight);
            var validationErrors = new List<ValidationFailure> { new(propertyName, errorMessage) };
            var validationException = new ValidationException(validationErrors);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateDogCommand>(), CancellationToken.None)).ThrowsAsync(validationException);
        
            // Act
            var result = await _dogController.CreateNewDog(createDogCommand);
        
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var errorResponse = Assert.IsType<ErrorResponse>(badRequestResult.Value);
            Assert.Equal("ValidationFailed", errorResponse.ErrorCode);
            Assert.Equal("One or more validation errors occurred", errorResponse.Message);
        }
    }