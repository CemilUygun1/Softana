using System;

namespace Softana.CQRS.Saler.Queries.Response
{
    public class GetSalerByIdQueryResponse
    {
        public int SalerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passwords { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}