using DigitalBank.Api.Adm.Authenticate.Business.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Login;
using DigitalBank.Api.Adm.Authenticate.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Security.JWT.Handler.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Security.JWT.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Business.Implementations
{
    public class AuthenticateBusiness : IAuthenticateBusiness
    {
        private IAdministratorBusiness _administratorBusiness;
        private IPermissionBusiness _permissionBusiness;
        private IEncryptorHandler _encryptorHandler;
        private ITokenHandler _tokenHandler;

        public AuthenticateBusiness(IAdministratorBusiness administratorBusiness, IEncryptorHandler encryptorHandler,
                                    ITokenHandler tokenHandler, IPermissionBusiness permissionBusiness)
        {
            _administratorBusiness = administratorBusiness;
            _permissionBusiness = permissionBusiness;
            _encryptorHandler = encryptorHandler;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenModel> LoginAsync(LoginModel login)
        {
            AdministratorModel customer = await _administratorBusiness.GetAdministratorByEmailAsync(login.Email);

            if (customer == null)
                throw new KeyNotFoundException("Usuário ou senha inválidos");

            await ValidateSamePasswordAsync(login.Password, customer.Password);

            string permissions = await _permissionBusiness.GetPermissionByAdministratorIdAsync(customer.Id);

            return await _tokenHandler.CreateJwtToken(customer, permissions);
        }

        private async Task ValidateSamePasswordAsync(string password, string passwordDb)
        {
            if (!await _encryptorHandler.CheckPassword(password, passwordDb))
                throw new KeyNotFoundException("Usuário ou senha inválidos");
        }
    }
}
