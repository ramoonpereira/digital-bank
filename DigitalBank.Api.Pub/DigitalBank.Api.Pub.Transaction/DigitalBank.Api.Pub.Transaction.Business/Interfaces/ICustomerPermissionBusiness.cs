using DigitalBank.Api.Pub.Transaction.Business.Models.CustomerPermission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Interfaces
{
    public interface ICustomerPermissionBusiness
    {
        Task<CustomerPermissionModel> InsertAsync(CustomerPermissionModel permission);
        Task<List<CustomerPermissionModel>> InsertAllInitialPermissionsInCustomerAsync(int customerId);
    }
}
