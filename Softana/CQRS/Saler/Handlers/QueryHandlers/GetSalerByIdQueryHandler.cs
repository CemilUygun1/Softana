using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Saler.Queries.Request;
using Softana.CQRS.Saler.Queries.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Softana.CQRS.Saler.Handlers.QueryHandlers
{
    public class GetSalerByIdQueryHandler : IRequestHandler<GetSalerByIdQueryRequest, GetSalerByIdQueryResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public GetSalerByIdQueryHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetSalerByIdQueryResponse> Handle(GetSalerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetSalerByIdQueryResponse saler = _context.Salers.Where(x => x.SalerId == request.SalerId).Select(x => _mapper.Map<Models.Saler, GetSalerByIdQueryResponse>(x)).FirstOrDefault();
            return saler;
        }
    }
}