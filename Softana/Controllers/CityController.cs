using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softana.Context;
using Softana.CQRS.City.Commands.Request;
using Softana.CQRS.City.Commands.Response;
using Softana.CQRS.City.Queries.Request;
using Softana.CQRS.City.Queries.Response;
using Softana.Models;

namespace Softana.Controllers;

[Authorize]
[ApiController]
[Route("api/Cities")]
public class CityController : ControllerBase
{
    private readonly SoftanaContext _context;
    IMediator _mediator;
    public CityController(SoftanaContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public List<City> GetCities()
    {
        return _context.Cities.OrderByDescending(x => x.Name).ToList();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        GetCityByIdQueryResponse response = await _mediator.Send(new GetCityByIdQueryRequest { CityId = Id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityCommandRequest request)
    {
        CreateCityCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCityCommandRequest request)
    {
        UpdateCityCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        DeleteCityCommandRequest request = new DeleteCityCommandRequest() { CityId = id };
        DeleteCityCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}