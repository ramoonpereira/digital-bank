using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBank.Api.Adm.Authenticate.Business.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Permission;
using DigitalBank.Api.Adm.Authenticate.Business.Repository;

namespace DigitalBank.Api.Adm.Authenticate.Business.Implementations
{
    public class PermissionBusiness : IPermissionBusiness
    {
        private IPermissionRepository _permissionRepository;
        public PermissionBusiness(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<string> GetPermissionByAdministratorIdAsync(int administratorId)
        {
            List<PermissionModel> permissions = await _permissionRepository.GetPermissionByAdministratorIdAsync(administratorId);

            string permissionsJoin = permissions.Any() ? string.Join(',', permissions.Select(p => p.Permissions)) : "";

            return permissionsJoin;
        }
    }
}
