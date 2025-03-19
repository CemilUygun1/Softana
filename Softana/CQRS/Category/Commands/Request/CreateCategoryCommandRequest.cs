using System;
using MediatR;
using Softana.CQRS.Category.Commands.Response;

namespace Softana.CQRS.Category.Commands.Request
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? Cdate { get; set; }
        public string Cuser { get; set; }
    }
}