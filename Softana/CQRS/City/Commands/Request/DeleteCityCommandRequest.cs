using System;
using MediatR;
using Softana.CQRS.City.Commands.Response;

namespace Softana.CQRS.City.Commands.Request
{
    public class DeleteCityCommandRequest : IRequest<DeleteCityCommandResponse>
    {
        public int CityId { get; set; }
    }
}