using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.CustomerPermission;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Repository.DbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Repository
{
    public class CustomerPermissionRepository : ICustomerPermissionRepository
    {
        private AppDbContext _appDbContext;
        public CustomerPermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CustomerPermissionModel> InsertAsync(CustomerPermissionModel permission)
        {

            var customerPermission = await _appDbContext.CustomerPermissions.AddAsync(permission);

            await _appDbContext.SaveChangesAsync();

            return customerPermission.Entity;
        }
    }
}
