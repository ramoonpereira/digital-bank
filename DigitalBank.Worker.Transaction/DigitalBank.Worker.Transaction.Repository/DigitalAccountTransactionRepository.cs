using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Worker.Transaction.Business.Repository;
using DigitalBank.Worker.Transaction.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Repository
{
    public class DigitalAccountTransactionRepository : IDigitalAccountTransactionRepository
    {
        private AppDbContext _appDbContext;
        public DigitalAccountTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<DigitalAccountTransactionModel> GetByIdAsync(int transactionId)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccountTransactions.Where(c => c.Id.Equals(transactionId)).FirstOrDefault();
            });
        }

        public async Task<List<DigitalAccountTransactionModel>> GetTransactionsPendingOrEffectedByPeriodAsync(int digitalAccountId, DateTime startDate, DateTime endDate)
        {
            return await _appDbContext.DigitalAccountTransactions
                       .Where(c => c.DigitalAccountId == digitalAccountId &&
                        c.CreatedDate >= startDate &&
                        c.CreatedDate <= endDate).ToListAsync();
        }

        public async Task<DigitalAccountTransactionModel> UpdateAsync(DigitalAccountTransactionModel digitalTransactionAccount)
        {
            var digitalTransactionAccountUpdate = _appDbContext.DigitalAccountTransactions.Update(digitalTransactionAccount);

            await _appDbContext.SaveChangesAsync();

            return digitalTransactionAccountUpdate.Entity;
        }
    }
}
