using System;

namespace Softana.CQRS.Saler.Queries.Response
{
    public class GetAllSalerQueryResponse
    {
        public int SalerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passwords { get; set; }
    }
}