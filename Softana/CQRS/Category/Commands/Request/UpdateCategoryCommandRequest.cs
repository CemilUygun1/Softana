using System;
using MediatR;
using Softana.CQRS.Category.Commands.Response;
using Softana.Models;

namespace Softana.CQRS.Category.Commands.Request
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? Udate { get; set; }
        public string Uuser { get; set; }
    }
}