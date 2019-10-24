using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Repository
{
    public interface IDigitalAccountRepository
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
    }
}
