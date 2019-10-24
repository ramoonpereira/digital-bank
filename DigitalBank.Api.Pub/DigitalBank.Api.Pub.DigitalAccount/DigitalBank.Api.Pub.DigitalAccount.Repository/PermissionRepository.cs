using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission.Enum;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private AppDbContext _appDbContext;
        public PermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PermissionModel>> GetPermissionsOnCreateCustomerAsync()
        {

            return await _appDbContext.Permissions.Where(c => c.Type == PermissionTypeEnum.Customer && c.Created).ToListAsync();
        }
    }
}
