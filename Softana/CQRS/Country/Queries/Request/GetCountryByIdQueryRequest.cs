using MediatR;
using Softana.CQRS.Country.Queries.Response;
using System;

namespace Softana.CQRS.Country.Queries.Request
{
    public class GetCountryByIdQueryRequest : IRequest<GetCountryByIdQueryResponse>
    {
        public int CountryId { get; set; }
    }
}