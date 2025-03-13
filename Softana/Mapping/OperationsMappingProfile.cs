using AutoMapper;
using Softana.CQRS.Saler.Commands.Request;
using Softana.CQRS.Saler.Queries.Response;
using Softana.Models;

namespace Softana.Mapping
{
    public class OperationsMappingProfile : Profile
    {
        public OperationsMappingProfile()
        {
            #region Saler
            #region Commands

            CreateMap<CreateSalerCommandRequest, Saler>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Passwords, opt => opt.MapFrom(src => src.Passwords));

            #endregion

            #region Queries

            CreateMap<Saler, GetSalerByIdQueryResponse>();

            #endregion
            #endregion
        }
    }
}
