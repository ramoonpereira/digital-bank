using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Handler.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Implementations
{
    public class DigitalAccountBusiness : IDigitalAccountBusiness
    {
        private IDigitalAccountRepository _digitalAccountRepository;


        public DigitalAccountBusiness(IDigitalAccountRepository digitalAccountRepository)
        {
            _digitalAccountRepository = digitalAccountRepository;
        }

        public async Task<DigitalAccountModel> GetByIdAsync(int digitalAccountId)
        {
            DigitalAccountModel digitalAccount = await _digitalAccountRepository.GetByIdAsync(digitalAccountId);

            if (digitalAccount == null)
                throw new KeyNotFoundException("Conta não localizada");

            return digitalAccount;
        }
    }
}
