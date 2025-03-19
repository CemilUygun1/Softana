using AutoMapper;
using Softana.CQRS.Category.Commands.Request;
using Softana.CQRS.Category.Queries.Response;
using Softana.CQRS.City.Queries.Response;
using Softana.CQRS.Country.Queries.Response;
using Softana.CQRS.Currency.Commands.Request;
using Softana.CQRS.Currency.Queries.Response;
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

            #region City

            #region Queries

            CreateMap<City, GetCityByIdQueryResponse>();

            #endregion
            #endregion

            #region Country

            #region Queries

            CreateMap<Country, GetCountryByIdQueryResponse>();

            #endregion
            #endregion

            #region Category
            #region Commands

            CreateMap<CreateCategoryCommandRequest, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Cdate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DeleteCategoryCommandRequest, Category>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Ddate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Duser, opt => opt.MapFrom(src => src.Duser));

            CreateMap<UpdateCategoryCommandRequest, Category>()
            .ForMember(dest => dest.Udate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Uuser, opt => opt.MapFrom(src => src.Uuser))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .MapOnlyIfChanged();

            #endregion

            #region Queries

            CreateMap<Category, GetCategoryByIdQueryResponse>();

            #endregion
            #endregion

            #region Currency
            #region Commands

            CreateMap<CreateCurrencyCommandRequest, Currency>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Cdate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DeleteCurrencyCommandRequest, Currency>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Ddate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Duser, opt => opt.MapFrom(src => src.Duser));

            CreateMap<UpdateCurrencyCommandRequest, Currency>()
            .ForMember(dest => dest.Udate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Uuser, opt => opt.MapFrom(src => src.Uuser))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .MapOnlyIfChanged();

            #endregion

            #region Queries

            CreateMap<Currency, GetCurrencyByIdQueryResponse>();

            #endregion
            #endregion
        }
    }
}