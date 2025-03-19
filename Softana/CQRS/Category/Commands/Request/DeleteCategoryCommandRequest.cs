using System;
using MediatR;
using Softana.CQRS.Category.Commands.Response;

namespace Softana.CQRS.Category.Commands.Request
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public int CategoryId { get; set; }
        public string Duser { get; set; }
    }
}