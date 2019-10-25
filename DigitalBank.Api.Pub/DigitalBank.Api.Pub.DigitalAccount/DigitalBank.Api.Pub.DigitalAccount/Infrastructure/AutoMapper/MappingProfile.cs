using AutoMapper;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.DigitalAccount.DTOs.v1.Requests;
using DigitalBank.Api.Pub.DigitalAccount.DTOs.v1.Responses;
using DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Model;

namespace DigitalBank.Api.Pub.DigitalAccount.Infrastructure.AutoMapper
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
            CreateMap<DigitalAccountModel, DigitalAccountResponseDTO>().ReverseMap();

            CreateMap<CustomerModel, DigitalAccountRequestDTO>().ReverseMap();
        }
    }
}
