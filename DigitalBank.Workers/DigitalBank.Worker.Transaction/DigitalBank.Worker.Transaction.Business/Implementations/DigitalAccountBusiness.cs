using DigitalBank.Worker.Transaction.Business.Interfaces;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Worker.Transaction.Business.Repository;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Business.Implementations
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

            return digitalAccount;
        }

        public async Task<DigitalAccountModel> UpdateAsync(DigitalAccountModel digitalAccount)
        {
            return await _digitalAccountRepository.UpdateAsync(digitalAccount);
        }
    }
}
