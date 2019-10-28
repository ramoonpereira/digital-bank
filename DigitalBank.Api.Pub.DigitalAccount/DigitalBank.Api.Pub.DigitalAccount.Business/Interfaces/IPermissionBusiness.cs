using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces
{
    public interface IPermissionBusiness
    {
        Task<List<PermissionModel>> GetPermissionsOnCreateCustomerAsync();
    }
}
