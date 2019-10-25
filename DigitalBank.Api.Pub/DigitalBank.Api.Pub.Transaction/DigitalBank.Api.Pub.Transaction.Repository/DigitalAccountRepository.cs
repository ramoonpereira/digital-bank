using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Repository.DbContext
{
    public class DigitalAccountRepository : IDigitalAccountRepository
    {
        private AppDbContext _appDbContext;
        public DigitalAccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccounts.Where(c => c.CustomerId.Equals(customerId)).FirstOrDefault();
            });
        }
        public Task<DigitalAccountModel> GetDigitalAccountByNumberAndDigitAsync(int number, char digit)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccounts.Where(c => c.Number.Equals(number) && c.Digit.Equals(digit)).FirstOrDefault();
            });
        }

        public async Task<DigitalAccountModel> InsertAsync(DigitalAccountModel digitalAccount)
        {
            var newDigitalAccount = await _appDbContext.DigitalAccounts.AddAsync(digitalAccount);

            await _appDbContext.SaveChangesAsync();

            return newDigitalAccount.Entity;
        }
    }
}
