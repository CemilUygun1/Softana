using System;

namespace Softana.CQRS.Category.Commands.Response
{
    public class CreateCategoryCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int CategoryId { get; set; }
    }
}