using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softana.Context;
using Softana.CQRS.Country.Queries.Request;
using Softana.CQRS.Country.Queries.Response;
using Softana.Models;

namespace Softana.Controllers;

[Authorize]
[ApiController]
[Route("api/Countries")]
public class CountryController : ControllerBase
{
    private readonly SoftanaContext _context;
    IMediator _mediator;
    public CountryController(SoftanaContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public List<Country> GetCountries()
    {
        return _context.Countries.OrderByDescending(x => x.Name).ToList();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        GetCountryByIdQueryResponse response = await _mediator.Send(new GetCountryByIdQueryRequest { CountryId = Id });
        return Ok(response);
    }
}