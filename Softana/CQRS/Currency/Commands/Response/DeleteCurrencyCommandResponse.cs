using System;

namespace Softana.CQRS.Currency.Commands.Response
{
    public class DeleteCurrencyCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}