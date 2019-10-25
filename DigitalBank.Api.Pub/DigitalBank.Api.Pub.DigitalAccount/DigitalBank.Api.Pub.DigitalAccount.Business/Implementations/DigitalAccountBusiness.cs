using DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Handler.Interfaces;
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
        private ICustomerBusiness _customerBusiness;
        private ITokenHandler _tokenHandler;
        private JwtSecurityToken _token;

        public DigitalAccountBusiness(IDigitalAccountRepository digitalAccountRepository,
                                      ICustomerBusiness customerBusiness,ITokenHandler tokenHandler)
        {
            _digitalAccountRepository = digitalAccountRepository;
            _customerBusiness = customerBusiness;
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

        public async Task<DigitalAccountModel> InsertAsync(CustomerModel customer)
        {
            CustomerModel newCustomer = await _customerBusiness.InsertAsync(customer);

            DigitalAccountModel digitalAccount = new DigitalAccountModel();

            digitalAccount = await GenerateNewDigitalAccountNumberAndDigit(digitalAccount);

            digitalAccount.CustomerId = newCustomer.Id;
            digitalAccount.Balance = 0m;
            digitalAccount.TransferLimitTransaction = 700m;
            digitalAccount.TransferLimitTransactionDay = 2000m;
            digitalAccount.Status = true;

            digitalAccount = await _digitalAccountRepository.InsertAsync(digitalAccount);

            return digitalAccount;
        }

        public async Task<DigitalAccountModel> GenerateNewDigitalAccountNumberAndDigit(DigitalAccountModel digitalAccount)
        {
            Random random = new Random();
            digitalAccount.Number = random.Next(Int32.MinValue, Int32.MaxValue);
            digitalAccount.Digit = 'X';

            bool exist = await ValidExistDigitalAccountNumberAndDigitAsync(digitalAccount.Number, digitalAccount.Digit);

            if (exist)
                await GenerateNewDigitalAccountNumberAndDigit(digitalAccount);

            return digitalAccount;
        }

        private async Task<bool> ValidExistDigitalAccountNumberAndDigitAsync(int number, char digit)
        {
            DigitalAccountModel account = await _digitalAccountRepository.GetDigitalAccountByNumberAndDigitAsync(number, digit);

            bool exist = (account != null);

            return exist;
        }
    }
}
