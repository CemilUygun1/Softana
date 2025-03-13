﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Softana.Context;
using Softana.CQRS.Saler.Commands.Request;
using Softana.CQRS.Saler.Commands.Response;
using Softana.CQRS.Saler.Queries.Request;
using Softana.CQRS.Saler.Queries.Response;
using Softana.Models;

namespace Softana.Controllers;

[ApiController]
[Route("api/Salers")]
public class SalerController : ControllerBase
{
    private readonly SoftanaContext _context;
    IMediator _mediator;
    public SalerController(SoftanaContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public List<Saler> GetSalers()
    {
        return _context.Salers.OrderByDescending(x => x.SalerId).ToList();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        GetSalerByIdQueryResponse response = await _mediator.Send(new GetSalerByIdQueryRequest { SalerId = Id });
        return Ok(response); 

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSalerCommandRequest request)
    {
        CreateSalerCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}