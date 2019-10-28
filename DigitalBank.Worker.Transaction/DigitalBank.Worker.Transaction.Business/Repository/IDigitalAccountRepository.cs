using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Business.Repository
{
    public interface IDigitalAccountRepository
    {
        Task<DigitalAccountModel> GetByIdAsync(int id);
        Task<DigitalAccountModel> UpdateAsync(DigitalAccountModel digitalAccount);
    }
}
