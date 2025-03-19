using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softana.Context;
using Softana.CQRS.Currency.Commands.Request;
using Softana.CQRS.Currency.Commands.Response;
using Softana.CQRS.Currency.Queries.Request;
using Softana.CQRS.Currency.Queries.Response;
using Softana.Models;

namespace Softana.Controllers;

[Authorize]
[ApiController]
[Route("api/Currencies")]
public class CurrencyController : ControllerBase
{
    private readonly SoftanaContext _context;
    IMediator _mediator;
    public CurrencyController(SoftanaContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public List<Currency> GetCurrencies()
    {
        return _context.Currencies.Where(x => x.IsDeleted != true).OrderByDescending(x => x.Name).ToList();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        GetCurrencyByIdQueryResponse response = await _mediator.Send(new GetCurrencyByIdQueryRequest { CurrencyId = Id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCurrencyCommandRequest request)
    {
        CreateCurrencyCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCurrencyCommandRequest request)
    {
        UpdateCurrencyCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        //, Duser = DecodeToken.GetClaim(Request.Headers["Authorization"], "Username")
        DeleteCurrencyCommandRequest request = new DeleteCurrencyCommandRequest() { CurrencyId = id };
        DeleteCurrencyCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}