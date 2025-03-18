using System;

namespace Softana.CQRS.City.Queries.Response
{
    public class GetCityByIdQueryResponse
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}