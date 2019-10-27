using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Transaction.Business.Repository
{
    public interface IDigitalAccountTransactionRepository
    {
        Task<List<DigitalAccountTransactionModel>> GetFilterAsync(DateTime startDate, DateTime endDate);
        Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate);

        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);
    }
}
