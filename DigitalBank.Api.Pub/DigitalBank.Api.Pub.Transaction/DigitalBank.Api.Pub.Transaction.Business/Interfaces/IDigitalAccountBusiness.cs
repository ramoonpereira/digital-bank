using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Interfaces
{
    public interface IDigitalAccountBusiness
    {
        Task<DigitalAccountModel> GetByIdAsync(int digitalAccountId);
    }
}
