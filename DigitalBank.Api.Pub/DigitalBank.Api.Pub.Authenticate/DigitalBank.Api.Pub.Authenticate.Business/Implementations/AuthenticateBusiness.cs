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
        private IEncryptorHandler _encryptorHandler;
        private ITokenHandler _tokenHandler;

        public AuthenticateBusiness(ICustomerBusiness customerBusiness, IEncryptorHandler encryptorHandler, ITokenHandler tokenHandler)
        {
            _customerBusiness = customerBusiness;
            _encryptorHandler = encryptorHandler;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenModel> LoginAsync(Login login)
        {
            Customer customer = await _customerBusiness.GetCustomerByEmailAsync(login.Email);

            if (customer == null)
                throw new KeyNotFoundException("Usuario ou senha invalidos");

            await ValidateSamePasswordAsync(login.Password, customer.Password);

            return await _tokenHandler.CreateJwtToken(customer);
        }

        private async Task ValidateSamePasswordAsync(string password, string passwordDb)
        {
            if (!await _encryptorHandler.CheckPassword(password, passwordDb))
                throw new KeyNotFoundException("Usuario ou senha invalidos");
        }
    }
}
