using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Currency.Commands.Request;
using Softana.CQRS.Currency.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Currency.Handlers.CommandHandlers
{
    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommandRequest, DeleteCurrencyCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public DeleteCurrencyCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteCurrencyCommandResponse> Handle(DeleteCurrencyCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbCurrency = _context.Currencies.FirstOrDefault(x => x.CurrencyId == request.CurrencyId);

            if (inDbCurrency is null)
            {
                return new DeleteCurrencyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Silinecek para birimi bulunamadý."
                };
            }

            try
            {
                _mapper.Map<DeleteCurrencyCommandRequest, Models.Currency>(request, inDbCurrency);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new DeleteCurrencyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new DeleteCurrencyCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Para birimi baþarýyla silindi"
            };
        }
    }
}