using DigitalBank.Api.Adm.Transaction.Business.Interfaces;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using DigitalBank.Api.Adm.Transaction.Business.Repository;
using DigitalBank.Api.Adm.Transaction.Security.JWT.Handler.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Transaction.Business.Implementations
{
    public class DigitalAccountTransactionBusiness : IDigitalAccountTransactionBusiness
    {
        private IDigitalAccountTransactionRepository _digitalAccountTransactionRepository;


        public DigitalAccountTransactionBusiness(IDigitalAccountTransactionRepository digitalAccountTransactionRepository)
        {
            _digitalAccountTransactionRepository = digitalAccountTransactionRepository;
        }

        public async Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId)
        {
            DigitalAccountTransactionModel transaction = await _digitalAccountTransactionRepository.GetByIdAsync(transactionId);

            if (transaction == null)
                throw new KeyNotFoundException("Transação não localizada");

            return transaction;
        }

        public async Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
                startDate = DateTime.Now.AddDays(-30);

            if (endDate == null)
                endDate = DateTime.Now;

            return await _digitalAccountTransactionRepository.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate.Value, endDate.Value);
        }

        public async Task<List<DigitalAccountTransactionModel>> GetFilterAsync(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
                startDate = DateTime.Now.AddDays(-30);

            if (endDate == null)
                endDate = DateTime.Now;

            return await _digitalAccountTransactionRepository.GetFilterAsync(startDate.Value, endDate.Value);
        }
    }
}
