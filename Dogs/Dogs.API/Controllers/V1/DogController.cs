using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Dogs.Application.Exceptions;
using Dogs.Application.Features.Dogs.Commands.CreateDog;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
using Dogs.Application.Models;
using Dogs.Application.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dogs.API.Controllers.V1;

/// <summary>
/// API controller for managing dog entities.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class DogController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DogController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator service for handling queries and commands.</param>
    public DogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets a ping response indicating the version of the Dogs house service.
    /// </summary>
    /// <returns>The ping response.</returns>
    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return Ok("Dogs house service. Version 1.0.1");
    }
    
    /// <summary>
    /// Gets a filtered list of dog entities.
    /// </summary>
    /// <param name="paginationFilter">The pagination filter to apply.</param>
    /// <param name="sortFilter">The sort filter to apply.</param>
    /// <returns>The filtered list of dog entities.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DogDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DogDto>>> GetFilteredDogsList([FromQuery] PaginationFilter paginationFilter,[FromQuery] SortFilter sortFilter)
    {
        var query = new GetDogsListQuery(paginationFilter, sortFilter);
        var dogs = await _mediator.Send(query);
        return Ok(dogs);
    }
    
    /// <summary>
    /// Creates a new dog.
    /// </summary>
    /// <param name="request">The command to create a new dog.</param>
    /// <returns>The ID of the created dog.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DogDto>>> CreateNewDog([FromBody] CreateDogCommand request)
    {
        try
        {
            var query = new CreateDogCommand(request.Name, request.Color, request.TailLength, request.Weight);
            var dogId = await _mediator.Send(query);
            return Ok(dogId);
        }
        catch (ValidationException ex)
        {
            var errorResponse = new ErrorResponse
            {
                ErrorCode = "ValidationFailed",
                Message = "One or more validation errors occurred",
                ValidationErrors = ex.Errors
            };
            return BadRequest(errorResponse);
        }
    }
}