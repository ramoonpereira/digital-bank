using AutoMapper;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Login;
using DigitalBank.Api.Adm.Authenticate.DTOs.v1.Requests;
using DigitalBank.Api.Adm.Authenticate.DTOs.v1.Responses;
using DigitalBank.Api.Adm.Authenticate.Security.JWT.Model;

namespace DigitalBank.Api.Adm.Authenticate.Infrastructure.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<LoginModel, LoginRequestDTO>().ReverseMap();
            CreateMap<AdministratorModel, AdministratorResponseDTO>().ReverseMap();
            CreateMap<TokenModel, TokenResponseDTO>().ReverseMap();
        }
    }
}
