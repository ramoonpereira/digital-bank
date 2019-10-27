using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Adm.Transaction.Business.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Transaction.Business.Repository
{
    public interface IDigitalAccountTransactionRepository
    {
        Task<PagedResultBase<DigitalAccountTransactionModel>> GetFilterAsync(DateTime startDate, DateTime endDate, int page, int pageSize);
        Task<PagedResultBase<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate, int page, int pageSize);

        Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId);
    }
}
