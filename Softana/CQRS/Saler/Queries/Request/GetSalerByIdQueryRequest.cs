using MediatR;
using Softana.CQRS.Saler.Queries.Response;
using System;

namespace Softana.CQRS.Saler.Queries.Request
{
    public class GetSalerByIdQueryRequest:IRequest<GetSalerByIdQueryResponse>
    {
        public int SalerId { get; set; }
    }
}