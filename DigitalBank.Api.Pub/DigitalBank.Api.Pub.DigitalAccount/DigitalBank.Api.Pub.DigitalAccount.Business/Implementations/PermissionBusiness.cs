using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Implementations
{
    public class PermissionBusiness : IPermissionBusiness
    {
        private IPermissionRepository _permissionRepository;

        public PermissionBusiness(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<List<PermissionModel>> GetPermissionsOnCreateCustomerAsync()
        {
            return await _permissionRepository.GetPermissionsOnCreateCustomerAsync();
        }

    }
}
