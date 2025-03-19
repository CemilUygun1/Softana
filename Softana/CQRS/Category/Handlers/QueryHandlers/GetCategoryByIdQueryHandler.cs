using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Category.Queries.Request;
using Softana.CQRS.Category.Queries.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Softana.CQRS.Category.Handlers.QueryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetCategoryByIdQueryResponse category = _context.Categories.Where(x => x.CategoryId == request.CategoryId).Select(x => _mapper.Map<Models.Category, GetCategoryByIdQueryResponse>(x)).FirstOrDefault();
            return category;
        }
    }
}