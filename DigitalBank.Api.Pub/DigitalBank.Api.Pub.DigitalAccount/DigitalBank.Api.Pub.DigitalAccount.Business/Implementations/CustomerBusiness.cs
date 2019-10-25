using System;
using System.Threading.Tasks;
using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Security.Encryptor.Handler.Interfaces;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Implementations
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerRepository _customerRepository;
        private ICustomerPermissionBusiness _customerPermissionBusiness;
        private IEncryptorHandler _encryptorHandler;

        public CustomerBusiness(ICustomerRepository customerRepository, ICustomerPermissionBusiness customerPermissionBusiness,
                                IEncryptorHandler encryptorHandler)
        {
            _customerRepository = customerRepository;
            _customerPermissionBusiness = customerPermissionBusiness;
            _encryptorHandler = encryptorHandler;
        }

        public async Task<CustomerModel> InsertAsync(CustomerModel newCustomer)
        {
            await ValidateCustomerEmailNotExistAsync(newCustomer.Email);

            newCustomer.Password = await _encryptorHandler.CreateEncryptPassword(newCustomer.Password);

            newCustomer = await _customerRepository.InsertAsync(newCustomer);

            await _customerPermissionBusiness.InsertAllInitialPermissionsInCustomerAsync(newCustomer.Id);

            return newCustomer;
        }

        private async Task ValidateCustomerEmailNotExistAsync(string email)
        {
            CustomerModel customer = await _customerRepository.GetCustomerByEmailAsync(email);

            if (customer != null)
                throw new ArgumentException("E-mail já cadastrado");
        }
    }
}
