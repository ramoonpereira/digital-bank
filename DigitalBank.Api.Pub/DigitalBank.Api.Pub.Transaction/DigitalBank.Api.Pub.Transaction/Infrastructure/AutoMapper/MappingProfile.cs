using AutoMapper;
using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.DTOs.v1.Requests;
using DigitalBank.Api.Pub.Transaction.DTOs.v1.Responses;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Model;

namespace DigitalBank.Api.Pub.Transaction.Infrastructure.AutoMapper
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
