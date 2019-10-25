using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using DigitalBank.Api.Pub.Transaction.Business.Models.CustomerPermission;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Repository.DbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Repository
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
