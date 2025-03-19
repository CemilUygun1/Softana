using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Currency.Commands.Request;
using Softana.CQRS.Currency.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Currency.Handlers.CommandHandlers
{
    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommandRequest, UpdateCurrencyCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public UpdateCurrencyCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateCurrencyCommandResponse> Handle(UpdateCurrencyCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbCurrency = _context.Currencies.FirstOrDefault(x => x.CurrencyId == request.CurrencyId);

            if (inDbCurrency is null)
            {
                return new UpdateCurrencyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Güncellenecek para birimi bulunamadý."
                };
            }

            try
            {
                _mapper.Map<UpdateCurrencyCommandRequest, Models.Currency>(request, inDbCurrency);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new UpdateCurrencyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new UpdateCurrencyCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Para birimi baþarýyla güncellendi"
            };
        }
    }
}