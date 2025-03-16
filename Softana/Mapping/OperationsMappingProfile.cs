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
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Cdate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DeleteSalerCommandRequest, Saler>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Ddate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Duser, opt => opt.MapFrom(src => src.Duser));

            CreateMap<UpdateSalerCommandRequest, Saler>()
            .ForMember(dest => dest.Udate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Uuser, opt => opt.MapFrom(src => src.Uuser))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .MapOnlyIfChanged();

            #endregion

            #region Queries

            CreateMap<Saler, GetSalerByIdQueryResponse>();

            #endregion
            #endregion
        }
    }
}
