using AutoMapper;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Adm.Transaction.DTOs.v1.Responses;
using DigitalBank.Api.Adm.Transaction.Security.JWT.Model;

namespace DigitalBank.Api.Adm.Transaction.Infrastructure.AutoMapper
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

            CreateMap<DigitalAccountTransactionModel, TransactionResponseDTO>().ReverseMap();
        }
    }
}
