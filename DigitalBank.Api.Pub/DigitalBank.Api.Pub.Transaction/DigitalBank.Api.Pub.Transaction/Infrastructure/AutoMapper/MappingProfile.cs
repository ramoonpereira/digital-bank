using AutoMapper;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
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
            CreateMap<DigitalAccountModel, DigitalAccountRequestDTO>().ReverseMap();
            
            CreateMap<DigitalAccountModel, DigitalAccountResponseDTO>().ReverseMap();


            CreateMap<DigitalAccountTransactionModel, TransactionResponseDTO>().ReverseMap();

            CreateMap<TransactionDepositRequestDTO, DigitalAccountTransactionModel>()
              .ForPath(s => s.DigitalAccountId,
                       c => c.MapFrom(m => m.DigitalAccountRecipient.Id))
              .ForPath(s => s.DigitalAccount,
                       c => c.MapFrom(m => m.DigitalAccountRecipient))
              .ForPath(s => s.DigitalAccountSenderId,
                       c => c.MapFrom(m => m.DigitalAccountSender.Id))
              .ForPath(s => s.DigitalAccountSender,
                       c => c.MapFrom(m => m.DigitalAccountSender));

            CreateMap<TransactionTransferRequestDTO, DigitalAccountTransactionModel>()
              .ForPath(s => s.DigitalAccountId,
                       c => c.MapFrom(m => m.DigitalAccountRecipient.Id))
              .ForPath(s => s.DigitalAccount,
                       c => c.MapFrom(m => m.DigitalAccountRecipient))
              .ForPath(s => s.DigitalAccountSenderId,
                       c => c.MapFrom(m => m.DigitalAccountSender.Id))
              .ForPath(s => s.DigitalAccountSender,
                       c => c.MapFrom(m => m.DigitalAccountSender));
        }
    }
}
