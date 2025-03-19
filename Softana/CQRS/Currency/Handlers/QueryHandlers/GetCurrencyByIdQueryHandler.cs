using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Currency.Queries.Request;
using Softana.CQRS.Currency.Queries.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Softana.CQRS.Currency.Handlers.QueryHandlers
{
    public class GetCurrencyByIdQueryHandler : IRequestHandler<GetCurrencyByIdQueryRequest, GetCurrencyByIdQueryResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public GetCurrencyByIdQueryHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCurrencyByIdQueryResponse> Handle(GetCurrencyByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetCurrencyByIdQueryResponse currency = _context.Currencies.Where(x => x.CurrencyId == request.CurrencyId).Select(x => _mapper.Map<Models.Currency, GetCurrencyByIdQueryResponse>(x)).FirstOrDefault();
            return currency;
        }
    }
}