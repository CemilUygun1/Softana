namespace Softana.CQRS.City.Commands.Response
{
    public class UpdateCityCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}