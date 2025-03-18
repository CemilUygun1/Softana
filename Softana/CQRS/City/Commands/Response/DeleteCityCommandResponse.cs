namespace Softana.CQRS.City.Commands.Response
{
    public class DeleteCityCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}