using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Business.Repository
{
    public interface IDigitalAccountTransactionRepository
    {
        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);

        Task<List<DigitalAccountTransactionModel>> GetTransactionsPendingOrEffectedByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate);

        Task<DigitalAccountTransactionModel> UpdateAsync(DigitalAccountTransactionModel digitalAccountTransaction);
    }
}
