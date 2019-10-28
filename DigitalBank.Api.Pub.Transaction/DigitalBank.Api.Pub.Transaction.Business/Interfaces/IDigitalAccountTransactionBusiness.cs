using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Pub.Transaction.Business.Pagination;
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
        Task<PagedResultBase<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime? startDate, DateTime? endDate, int page, int pageSize);
        Task Authorize(string token);
    }
}
