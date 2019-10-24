using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Handler.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Implementations
{
    public class DigitalAccountBusiness : IDigitalAccountBusiness
    {
        private IDigitalAccountRepository _digitalAccountRepository;
        private ITokenHandler _tokenHandler;
        private JwtSecurityToken _token;

        public DigitalAccountBusiness(IDigitalAccountRepository digitalAccountRepository, ITokenHandler tokenHandler)
        {
            _digitalAccountRepository = digitalAccountRepository;
            _tokenHandler = tokenHandler;
        }

        public async Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId)
        {
            ValidRequestCustomerIdWithCustomerToken(customerId);

            DigitalAccountModel digitalAccount = await _digitalAccountRepository.GetDigitalAccountByCustomerIdAsync(customerId);

            if (digitalAccount == null)
                throw new KeyNotFoundException("Conta não localizada");

            return digitalAccount;
        }

        private void ValidRequestCustomerIdWithCustomerToken(int customerId)
        {
            int customerTokenId;

            Int32.TryParse(_token.Claims.Where(x => x.Type.Equals("Id")).FirstOrDefault().Value, out customerTokenId);

            if (customerTokenId == 0 || customerTokenId != customerId)
                throw new KeyNotFoundException("Conta não localizada");
        }

        public async Task Authorize(string accessToken)
        {
            _token = await _tokenHandler.DecodeJwtToken(accessToken);
        }
    }
}
