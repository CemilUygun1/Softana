using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Saler.Commands.Request;
using Softana.CQRS.Saler.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Saler.Handlers.CommandHandlers
{
    public class CreateSalerCommandHandler : IRequestHandler<CreateSalerCommandRequest, CreateSalerCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public CreateSalerCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateSalerCommandResponse> Handle(CreateSalerCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbSaler = _context.Salers.FirstOrDefault(x => x.Email == request.Email);

            if (inDbSaler is not null)
            {
                return new CreateSalerCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Sat�c� zaten mevcut"
                };
            }

            Models.Saler newSaler = _mapper.Map<Models.Saler>(request);

            _context.Add(newSaler);
            _context.SaveChanges();

            return new CreateSalerCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Sat�c� ba�ar�yla olu�turuldu.",
                SalerId = newSaler.SalerId
            };
        }
    }
}