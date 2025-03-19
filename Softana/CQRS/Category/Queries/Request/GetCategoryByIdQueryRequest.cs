using MediatR;
using Softana.CQRS.Category.Queries.Response;
using System;

namespace Softana.CQRS.Category.Queries.Request
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
    {
        public int CategoryId { get; set; }
    }
}