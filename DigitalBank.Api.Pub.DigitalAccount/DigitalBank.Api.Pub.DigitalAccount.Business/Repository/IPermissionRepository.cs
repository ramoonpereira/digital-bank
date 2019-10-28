
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Repository
{
    public interface IPermissionRepository
    {
        Task<List<PermissionModel>> GetPermissionsOnCreateCustomerAsync();
    }
}
