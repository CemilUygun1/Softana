using System;

namespace Softana.CQRS.Saler.Commands.Response
{
    public class CreateSalerCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int SalerId { get; set; }
    }
}