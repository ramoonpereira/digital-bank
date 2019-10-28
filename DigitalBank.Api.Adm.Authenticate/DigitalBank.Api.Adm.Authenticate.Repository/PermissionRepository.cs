using DigitalBank.Api.Adm.Authenticate.Business.Models.Permission;
using DigitalBank.Api.Adm.Authenticate.Business.Repository;
using DigitalBank.Api.Adm.Authenticate.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private AppDbContext _appDbContext;
        public PermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PermissionModel>> GetPermissionByAdministratorIdAsync(int customerId)
        {
            return await _appDbContext.Permissions.Where(c => c.AdministratorId.Equals(customerId)).ToListAsync();
        }
    }
}
