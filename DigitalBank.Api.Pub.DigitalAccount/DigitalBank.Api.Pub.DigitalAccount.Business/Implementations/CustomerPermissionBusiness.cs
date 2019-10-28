using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.CustomerPermission;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Implementations
{
    public class CustomerPermissionBusiness : ICustomerPermissionBusiness
    {
        private ICustomerPermissionRepository _customerPermissionRepository;
        private IPermissionBusiness _permissionBusiness;

        public CustomerPermissionBusiness(ICustomerPermissionRepository customerPermissionRepository, IPermissionBusiness permissionBusiness)
        {
            _customerPermissionRepository = customerPermissionRepository;
            _permissionBusiness = permissionBusiness;
        }

        public async Task<CustomerPermissionModel> InsertAsync(CustomerPermissionModel permission)
        {
            return await _customerPermissionRepository.InsertAsync(permission);
        }

        public async Task<List<CustomerPermissionModel>> InsertAllInitialPermissionsInCustomerAsync(int customerId)
        {
            List<PermissionModel> permissions = await _permissionBusiness.GetPermissionsOnCreateCustomerAsync();

            var customerPermissions = new List<CustomerPermissionModel>();

            foreach (var permission in permissions)
            {
                var customerPermission = new CustomerPermissionModel()
                {
                    CustomerId = customerId,
                    PermissionId = permission.Id,
                    Permissions = permission.Permissions,
                };

                customerPermissions.Add(await InsertAsync(customerPermission));
            }

            return customerPermissions;
        }
    }
}
