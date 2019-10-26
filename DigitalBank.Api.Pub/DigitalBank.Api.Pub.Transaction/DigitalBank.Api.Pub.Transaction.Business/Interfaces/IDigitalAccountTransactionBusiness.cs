using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Interfaces
{
    public interface IDigitalAccountTransactionBusiness
    {
        Task<DigitalAccountTransactionModel> CreateTransactionDepositAsync(DigitalAccountTransactionModel transaction);
        Task<DigitalAccountTransactionModel> CreateTransactionTransferAsync(DigitalAccountTransactionModel transaction);
        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);
        Task<DigitalAccountTransactionModel> InsertAsync(DigitalAccountTransactionModel digitalAccountTransaction);
        Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime? startDate, DateTime? endDate);
        Task Authorize(string token);
    }
}
