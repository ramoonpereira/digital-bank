using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Pub.Transaction.Business.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Repository
{
    public interface IDigitalAccountTransactionRepository
    {
        Task<DigitalAccountTransactionModel> InsertAsync(DigitalAccountTransactionModel digitalAccountTransaction);

        Task<PagedResultBase<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate, int page, int pageSize);

        Task<List<DigitalAccountTransactionModel>> GetTransactionsEffectedByDateAsync(int digitalAccountId,DateTime date);

        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);
    }
}
