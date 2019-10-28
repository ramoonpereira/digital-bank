using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.DigitalAccount.Business.Pagination;
using DigitalBank.Api.Adm.DigitalAccount.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.Repository.DbContext
{
    public class DigitalAccountRepository : IDigitalAccountRepository
    {
        private AppDbContext _appDbContext;
        public DigitalAccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PagedResultBase<DigitalAccountModel>> GetAllAsync(int page, int pageSize)
        {
            return await PaginationService.GetPagination(_appDbContext.DigitalAccounts, page, pageSize);
        }

        public Task<DigitalAccountModel> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccounts.Where(c => c.Id.Equals(id)).FirstOrDefault();
            });
        }

        public Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId)
        {
            return Task.Run(() =>
            {
                return _appDbContext.DigitalAccounts.Where(c => c.CustomerId.Equals(customerId)).FirstOrDefault();
            });
        }
    }
}
