using System;

namespace Softana.CQRS.Currency.Commands.Response
{
    public class UpdateCurrencyCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}