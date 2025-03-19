using System;

namespace Softana.CQRS.Category.Queries.Response
{
    public class GetCategoryByIdQueryResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}