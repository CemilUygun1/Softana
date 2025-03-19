using System;

namespace Softana.CQRS.Currency.Commands.Response
{
    public class CreateCurrencyCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int CurrencyId { get; set; }
    }
}