using System;
using MediatR;
using Softana.CQRS.City.Commands.Response;

namespace Softana.CQRS.City.Commands.Request
{
    public class CreateCityCommandRequest : IRequest<CreateCityCommandResponse>
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string StateName { get; set; }
    }
}