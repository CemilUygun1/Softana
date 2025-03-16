using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Saler.Commands.Request;
using Softana.CQRS.Saler.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Saler.Handlers.CommandHandlers
{
    public class DeleteSalerCommandHandler : IRequestHandler<DeleteSalerCommandRequest, DeleteSalerCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public DeleteSalerCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteSalerCommandResponse> Handle(DeleteSalerCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbsaler = _context.Salers.FirstOrDefault(x => x.SalerId == request.SalerId);

            if (inDbsaler is null)
            {
                return new DeleteSalerCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Silinecek satýcý bulunamadý."
                };
            }

            try
            {
                _mapper.Map<DeleteSalerCommandRequest, Models.Saler>(request,inDbsaler);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new DeleteSalerCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new DeleteSalerCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Satýcý baþarýyla silindi"
            };
        }
    }
}