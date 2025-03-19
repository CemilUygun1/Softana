using AutoMapper;
using MediatR;
using Softana.Context;
using Softana.CQRS.Category.Commands.Request;
using Softana.CQRS.Category.Commands.Response;
using Softana.Models;
using System;

namespace Softana.CQRS.Category.Handlers.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly SoftanaContext _context;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(SoftanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inDbCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == request.CategoryId);

            if (inDbCategory is null)
            {
                return new DeleteCategoryCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Silinecek kategori bulunamadý."
                };
            }

            try
            {
                _mapper.Map<DeleteCategoryCommandRequest, Models.Category>(request, inDbCategory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new DeleteCategoryCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return new DeleteCategoryCommandResponse
            {
                IsSuccess = true,
                ErrorMessage = "Kategori baþarýyla silindi"
            };
        }
    }
}