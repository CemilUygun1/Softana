using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Currency.Commands.Request;
using Softana.CQRS.Currency.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Currency.Handlers.CommandHandlers
{
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommandRequest, CreateCurrencyCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public CreateCurrencyCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCurrencyCommandResponse> Handle(CreateCurrencyCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbCurrency = _context.Currencies.FirstOrDefault(x => x.Name == request.Name);

            if (inDbCurrency is not null)
            {
                return new CreateCurrencyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Para birimi zaten mevcut."
                };
            }

            Models.Currency newCurrency = _mapper.Map<Models.Currency>(request);

            _context.Add(newCurrency);
            _context.SaveChanges();

            return new CreateCurrencyCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Para birimi baþarýyla oluþturuldu.",
                CurrencyId = newCurrency.CurrencyId
            };
        }
    }
}