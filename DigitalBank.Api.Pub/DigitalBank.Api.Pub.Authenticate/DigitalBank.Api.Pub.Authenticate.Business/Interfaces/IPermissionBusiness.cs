using DigitalBank.Api.Pub.Authenticate.Business.Models.Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Business.Interfaces
{
    public interface IPermissionBusiness
    {
        Task<string> GetPermissionByCustomerIdAsync(int customerId);
    }
}
