using System;

namespace Softana.CQRS.Category.Commands.Response
{
    public class UpdateCategoryCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}