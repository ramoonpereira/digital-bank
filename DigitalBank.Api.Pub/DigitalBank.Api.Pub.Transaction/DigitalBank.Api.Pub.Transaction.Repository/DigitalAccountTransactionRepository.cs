using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Repository
{
    public class DigitalAccountTransactionRepository : IDigitalAccountTransactionRepository
    {
        private AppDbContext _appDbContext;
        public DigitalAccountTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DigitalAccountTransactionModel> InsertAsync(DigitalAccountTransactionModel digitalAccountTransaction)
        {
            var newDigitalAccountTransaction = await _appDbContext.DigitalAccountTransactions.AddAsync(digitalAccountTransaction);

            await _appDbContext.SaveChangesAsync();

            return newDigitalAccountTransaction.Entity;
        }

        public async Task<List<DigitalAccountTransactionModel>> GetAllTransactionsByPeriodAsync(DateTime startDate,DateTime endDate)
        {

            throw new NotImplementedException();
        }

        public async Task<List<DigitalAccountTransactionModel>> GetTransactionsByDateAsync(DateTime date)
        {

            throw new NotImplementedException();
        }
    }
}
