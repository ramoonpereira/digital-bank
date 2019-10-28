using DigitalBank.Api.Pub.Authenticate.Business.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Login;
using DigitalBank.Api.Pub.Authenticate.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Handler.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Business.Implementations
{
    public class AuthenticateBusiness : IAuthenticateBusiness
    {
        private ICustomerBusiness _customerBusiness;
        private IPermissionBusiness _permissionBusiness;
        private IEncryptorHandler _encryptorHandler;
        private ITokenHandler _tokenHandler;

        public AuthenticateBusiness(ICustomerBusiness customerBusiness, IEncryptorHandler encryptorHandler,
                                    ITokenHandler tokenHandler, IPermissionBusiness permissionBusiness)
        {
            _customerBusiness = customerBusiness;
            _permissionBusiness = permissionBusiness;
            _encryptorHandler = encryptorHandler;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenModel> LoginAsync(LoginModel login)
        {
            CustomerModel customer = await _customerBusiness.GetCustomerByEmailAsync(login.Email);

            if (customer == null)
                throw new KeyNotFoundException("Usuário ou senha inválidos");

            await ValidateSamePasswordAsync(login.Password, customer.Password);

            string permissions = await _permissionBusiness.GetPermissionByCustomerIdAsync(customer.Id);

            return await _tokenHandler.CreateJwtToken(customer, permissions);
        }

        private async Task ValidateSamePasswordAsync(string password, string passwordDb)
        {
            if (!await _encryptorHandler.CheckPassword(password, passwordDb))
                throw new KeyNotFoundException("Usuário ou senha inválidos");
        }
    }
}
