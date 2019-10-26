using DigitalBank.Api.Adm.Authenticate.Business.Models.Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Business.Interfaces
{
    public interface IPermissionBusiness
    {
        Task<string> GetPermissionByAdministratorIdAsync(int customerId);
    }
}
