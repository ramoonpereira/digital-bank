using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Worker.Transaction.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Repository.DbContext
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

        public async Task<DigitalAccountModel> UpdateAsync(DigitalAccountModel digitalAccount)
        {
            var digitalAccountUpdate =  _appDbContext.DigitalAccounts.Update(digitalAccount);

            await _appDbContext.SaveChangesAsync();

            return digitalAccountUpdate.Entity;
        }
    }
}
