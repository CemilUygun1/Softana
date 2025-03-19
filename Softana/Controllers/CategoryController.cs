using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softana.Context;
using Softana.CQRS.Category.Commands.Request;
using Softana.CQRS.Category.Commands.Response;
using Softana.CQRS.Category.Queries.Request;
using Softana.CQRS.Category.Queries.Response;
using Softana.Models;

namespace Softana.Controllers;

[Authorize]
[ApiController]
[Route("api/Categories")]
public class CategoryController : ControllerBase
{
    private readonly SoftanaContext _context;
    IMediator _mediator;
    public CategoryController(SoftanaContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public List<Category> GetCategories()
    {
        return _context.Categories.Where(x => x.IsDeleted != true).OrderByDescending(x => x.Name).ToList();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int Id)
    {
        GetCategoryByIdQueryResponse response = await _mediator.Send(new GetCategoryByIdQueryRequest { CategoryId = Id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
    {
        CreateCategoryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommandRequest request)
    {
        UpdateCategoryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        //, Duser = DecodeToken.GetClaim(Request.Headers["Authorization"], "Username")
        DeleteCategoryCommandRequest request = new DeleteCategoryCommandRequest() { CategoryId = id };
        DeleteCategoryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
