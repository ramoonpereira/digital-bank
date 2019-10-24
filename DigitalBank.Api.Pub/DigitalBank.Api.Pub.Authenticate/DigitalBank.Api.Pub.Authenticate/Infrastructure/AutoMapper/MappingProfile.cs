using AutoMapper;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Login;
using DigitalBank.Api.Pub.Authenticate.DTOs.v1.Requests;
using DigitalBank.Api.Pub.Authenticate.DTOs.v1.Responses;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Model;

namespace DigitalBank.Api.Pub.Authenticate.Infrastructure.AutoMapper
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
            CreateMap<CustomerModel, CustomerResponseDTO>().ReverseMap();
            CreateMap<TokenModel, TokenResponseDTO>().ReverseMap();
        }
    }
}
