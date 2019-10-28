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

        public Task<DigitalAccountModel> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccounts.Where(c => c.Id.Equals(id)).FirstOrDefault();
            });
        }
    }
}
