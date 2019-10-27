using AutoMapper;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.DigitalAccount.DTOs.v1.Responses;
using DigitalBank.Api.Adm.DigitalAccount.Security.JWT.Model;

namespace DigitalBank.Api.Adm.DigitalAccount.Infrastructure.AutoMapper
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
        }
    }
}
