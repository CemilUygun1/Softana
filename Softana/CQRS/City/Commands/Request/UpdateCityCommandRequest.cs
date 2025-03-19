using System;
using MediatR;
using Softana.CQRS.City.Commands.Response;
using Softana.Models;

namespace Softana.CQRS.City.Commands.Request
{
    public class UpdateCityCommandRequest : IRequest<UpdateCityCommandResponse>
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

        public List<Models.Country> Countries { get; set; }
    }
}