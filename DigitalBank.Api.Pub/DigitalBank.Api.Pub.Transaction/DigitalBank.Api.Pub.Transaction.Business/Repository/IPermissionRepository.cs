
using DigitalBank.Api.Pub.Transaction.Business.Models.Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Repository
{
    public interface IPermissionRepository
    {
        Task<List<PermissionModel>> GetPermissionsOnCreateCustomerAsync();
    }
}
