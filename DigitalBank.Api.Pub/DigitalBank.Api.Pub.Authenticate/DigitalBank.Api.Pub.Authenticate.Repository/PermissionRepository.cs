using DigitalBank.Api.Pub.Authenticate.Business.Models.Permission;
using DigitalBank.Api.Pub.Authenticate.Business.Repository;
using DigitalBank.Api.Pub.Authenticate.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private AppDbContext _appDbContext;
        public PermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Permission>> GetPermissionByCustomerIdAsync(int customerId)
        {
            return await _appDbContext.Permissions.Where(c => c.CustomerId.Equals(customerId)).ToListAsync();
        }
    }
}
