using MediatR;
using Softana.CQRS.City.Queries.Response;
using System;

namespace Softana.CQRS.City.Queries.Request
{
    public class GetCityByIdQueryRequest : IRequest<GetCityByIdQueryResponse>
    {
        public int CityId { get; set; }
    }
}