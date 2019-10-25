using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Models.Permission;
using DigitalBank.Api.Pub.Transaction.Business.Repository;

namespace DigitalBank.Api.Pub.Transaction.Business.Implementations
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
