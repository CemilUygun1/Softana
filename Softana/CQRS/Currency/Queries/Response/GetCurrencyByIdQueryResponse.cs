using System;

namespace Softana.CQRS.Currency.Queries.Response
{
    public class GetCurrencyByIdQueryResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}