using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.City.Queries.Request;
using Softana.CQRS.City.Queries.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Softana.CQRS.City.Handlers.QueryHandlers
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQueryRequest, GetCityByIdQueryResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCityByIdQueryResponse> Handle(GetCityByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetCityByIdQueryResponse city = _context.Cities.Where(x => x.CityId == request.CityId).Select(x => _mapper.Map<Models.City, GetCityByIdQueryResponse>(x)).FirstOrDefault();
            return city;
        }
    }
}