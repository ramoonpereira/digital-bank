using DigitalBank.Api.Pub.Transaction.Business.Models.CustomerPermission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Repository
{
    public interface ICustomerPermissionRepository
    {
        Task<CustomerPermissionModel> InsertAsync(CustomerPermissionModel permission);
    }
}
