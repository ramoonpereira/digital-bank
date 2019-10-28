using DigitalBank.Api.Pub.Authenticate.Business.Models.Permission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Business.Repository
{
    public interface IPermissionRepository
    {
        Task<List<PermissionModel>> GetPermissionByCustomerIdAsync(int customerId);
    }
}
