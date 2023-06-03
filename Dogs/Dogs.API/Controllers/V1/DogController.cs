using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Dogs.Application.Features.Dogs.Queries.GetDogsList;
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
    public async Task<ActionResult<IEnumerable<DogDto>>> GetFilteredDogsList(PaginationFilter paginationFilter, SortFilter sortFilter)
    {
        var query = new GetDogsListQuery(paginationFilter, sortFilter);
        var dogs = await _mediator.Send(query);
        return Ok(dogs);
    }
}