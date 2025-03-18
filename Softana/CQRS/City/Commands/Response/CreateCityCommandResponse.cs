using System;

namespace Softana.CQRS.City.Commands.Response
{
    public class CreateCityCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int CityId { get; set; }
    }
}