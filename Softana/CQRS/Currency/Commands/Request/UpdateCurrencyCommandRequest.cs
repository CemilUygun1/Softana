using System;
using MediatR;
using Softana.CQRS.Currency.Commands.Response;
using Softana.Models;

namespace Softana.CQRS.Currency.Commands.Request
{
    public class UpdateCurrencyCommandRequest : IRequest<UpdateCurrencyCommandResponse>
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? Udate { get; set; }
        public string Uuser { get; set; }
    }
}