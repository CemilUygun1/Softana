namespace Softana.CQRS.Saler.Commands.Response
{
    public class DeleteSalerCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}