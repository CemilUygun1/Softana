using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Saler.Commands.Request;
using Softana.CQRS.Saler.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Saler.Handlers.CommandHandlers
{
    public class UpdateSalerCommandHandler : IRequestHandler<UpdateSalerCommandRequest, UpdateSalerCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public UpdateSalerCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateSalerCommandResponse> Handle(UpdateSalerCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbsaler = _context.Salers.FirstOrDefault(x => x.SalerId == request.SalerId);

            if (inDbsaler is null)
            {
                return new UpdateSalerCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Güncellenecek satýcý bulunamadý."
                };
            }

            try
            {
                _mapper.Map<UpdateSalerCommandRequest, Models.Saler>(request, inDbsaler);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new UpdateSalerCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new UpdateSalerCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Satýcý baþarýyla güncellendi"
            };
        }
    }
}