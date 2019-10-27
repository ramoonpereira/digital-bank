using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Transaction.Business.Interfaces
{
    public interface IDigitalAccountTransactionBusiness
    {
        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);
        Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime? startDate, DateTime? endDate);

        Task<List<DigitalAccountTransactionModel>> GetFilterAsync(DateTime? startDate, DateTime? endDate);
    }
}
