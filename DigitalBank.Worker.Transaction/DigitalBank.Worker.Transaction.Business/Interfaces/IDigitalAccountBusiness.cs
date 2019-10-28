using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Business.Interfaces
{
    public interface IDigitalAccountBusiness
    {
        Task<DigitalAccountModel> GetByIdAsync(int digitalAccountId);

        Task<DigitalAccountModel> UpdateAsync(DigitalAccountModel digitalAccount);
    }
}
