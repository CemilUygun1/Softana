using MediatR;
using Softana.CQRS.Currency.Queries.Response;
using System;

namespace Softana.CQRS.Currency.Queries.Request
{
    public class GetCurrencyByIdQueryRequest : IRequest<GetCurrencyByIdQueryResponse>
    {
        public int CurrencyId { get; set; }
    }
}