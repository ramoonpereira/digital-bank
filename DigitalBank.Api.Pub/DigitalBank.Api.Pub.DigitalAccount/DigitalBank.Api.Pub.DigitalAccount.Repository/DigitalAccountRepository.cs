using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Repository.DbContext
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
            }
            );
        }
    }
}
