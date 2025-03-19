using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Category.Commands.Request;
using Softana.CQRS.Category.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Category.Handlers.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbCategory = _context.Categories.FirstOrDefault(x => x.Name == request.Name);

            if (inDbCategory is not null)
            {
                return new CreateCategoryCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Kategori zaten mevcut."
                };
            }

            Models.Category newCategory = _mapper.Map<Models.Category>(request);

            _context.Add(newCategory);
            _context.SaveChanges();

            return new CreateCategoryCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Kategori baþarýyla oluþturuldu.",
                CategoryId = newCategory.CategoryId
            };
        }
    }
}