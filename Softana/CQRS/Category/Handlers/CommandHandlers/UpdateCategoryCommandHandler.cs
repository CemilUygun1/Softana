using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Category.Commands.Request;
using Softana.CQRS.Category.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Category.Handlers.CommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == request.CategoryId);

            if (inDbCategory is null)
            {
                return new UpdateCategoryCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Güncellenecek kategori bulunamadý."
                };
            }

            try
            {
                _mapper.Map<UpdateCategoryCommandRequest, Models.Category>(request, inDbCategory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new UpdateCategoryCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new UpdateCategoryCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Kategori baþarýyla güncellendi"
            };
        }
    }
}