using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Country.Queries.Request;
using Softana.CQRS.Country.Queries.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Softana.CQRS.Country.Handlers.QueryHandlers
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQueryRequest, GetCountryByIdQueryResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCountryByIdQueryResponse> Handle(GetCountryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetCountryByIdQueryResponse country = _context.Countries.Where(x => x.CountryId == request.CountryId).Select(x => _mapper.Map<Models.Country, GetCountryByIdQueryResponse>(x)).FirstOrDefault();
            return country;
        }
    }
}