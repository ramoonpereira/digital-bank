using DigitalBank.Api.Adm.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.DigitalAccount.Business.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.Business.Implementations
{
    public class DigitalAccountBusiness : IDigitalAccountBusiness
    {
        private IDigitalAccountRepository _digitalAccountRepository;

        public DigitalAccountBusiness(IDigitalAccountRepository digitalAccountRepository)
        {
            _digitalAccountRepository = digitalAccountRepository;
        }

        public async Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId)
        {
            DigitalAccountModel digitalAccount = await _digitalAccountRepository.GetDigitalAccountByCustomerIdAsync(customerId);

            if (digitalAccount == null)
                throw new KeyNotFoundException("Conta não localizada");

            return digitalAccount;
        }

        public async Task<DigitalAccountModel> GetByIdAsync(int id)
        {
            DigitalAccountModel digitalAccount = await _digitalAccountRepository.GetByIdAsync(id);

            if (digitalAccount == null)
                throw new KeyNotFoundException("Conta não localizada");

            return digitalAccount;
        }

        public async Task<List<DigitalAccountModel>> GetAllAsync()
        {
            return await _digitalAccountRepository.GetAllAsync();
        }
    }
}
