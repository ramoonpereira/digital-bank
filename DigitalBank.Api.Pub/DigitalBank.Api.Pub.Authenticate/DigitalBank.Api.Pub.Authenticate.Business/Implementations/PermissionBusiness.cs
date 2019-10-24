using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBank.Api.Pub.Authenticate.Business.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Permission;
using DigitalBank.Api.Pub.Authenticate.Business.Repository;

namespace DigitalBank.Api.Pub.Authenticate.Business.Implementations
{
    public class PermissionBusiness : IPermissionBusiness
    {
        private IPermissionRepository _permissionRepository;
        public PermissionBusiness(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<string> GetPermissionByCustomerIdAsync(int customerId)
        {
            List<Permission> permissions = await _permissionRepository.GetPermissionByCustomerIdAsync(customerId);

            string permissionsJoin = permissions.Any() ? string.Join(',', permissions.Select(p => p.Permissions)) : "";

            return permissionsJoin;
        }
    }
}
