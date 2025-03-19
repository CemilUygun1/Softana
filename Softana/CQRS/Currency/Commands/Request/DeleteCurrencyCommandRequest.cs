using System;
using MediatR;
using Softana.CQRS.Currency.Commands.Response;

namespace Softana.CQRS.Currency.Commands.Request
{
    public class DeleteCurrencyCommandRequest : IRequest<DeleteCurrencyCommandResponse>
    {
        public int CurrencyId { get; set; }
        public string Duser { get; set; }
    }
}