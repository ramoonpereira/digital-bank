using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Adm.Transaction.Business.Pagination;
using DigitalBank.Api.Adm.Transaction.Business.Repository;
using DigitalBank.Api.Adm.Transaction.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Transaction.Repository
{
    public class DigitalAccountTransactionRepository : IDigitalAccountTransactionRepository
    {
        private AppDbContext _appDbContext;
        public DigitalAccountTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PagedResultBase<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate, int page, int pageSize)
        {
            var query = _appDbContext.DigitalAccountTransactions
                                   .Where(c => c.DigitalAccountId == digitalAccountId &&
                                    c.CreatedDate.Date >= startDate.Date &&
                                    c.CreatedDate.Date <= endDate.Date);

            return await PaginationService.GetPagination(query, page, pageSize);
        }

        public Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccountTransactions.Where(c => c.Id.Equals(transactionId)).FirstOrDefault();
            });
        }

        public async Task<PagedResultBase<DigitalAccountTransactionModel>> GetFilterAsync(DateTime startDate, DateTime endDate, int page, int pageSize)
        {
            var query = _appDbContext.DigitalAccountTransactions.Where(c => c.CreatedDate.Date >= startDate.Date &&
                                   c.CreatedDate.Date <= endDate.Date);

            return await PaginationService.GetPagination(query, page, pageSize);
        }
    }
}
