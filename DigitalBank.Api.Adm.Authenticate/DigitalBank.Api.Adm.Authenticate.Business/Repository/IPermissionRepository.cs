using DigitalBank.Api.Adm.Authenticate.Business.Models.Permission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Business.Repository
{
    public interface IPermissionRepository
    {
        Task<List<PermissionModel>> GetPermissionByAdministratorIdAsync(int customerId);
    }
}
