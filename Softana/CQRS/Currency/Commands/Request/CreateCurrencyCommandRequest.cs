using System;
using MediatR;
using Softana.CQRS.Currency.Commands.Response;

namespace Softana.CQRS.Currency.Commands.Request
{
    public class CreateCurrencyCommandRequest : IRequest<CreateCurrencyCommandResponse>
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? Cdate { get; set; }
        public string Cuser { get; set; }
    }
}