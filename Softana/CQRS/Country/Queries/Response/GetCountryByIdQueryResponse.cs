using System;

namespace Softana.CQRS.Country.Queries.Response
{
    public class GetCountryByIdQueryResponse
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Code2 { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}