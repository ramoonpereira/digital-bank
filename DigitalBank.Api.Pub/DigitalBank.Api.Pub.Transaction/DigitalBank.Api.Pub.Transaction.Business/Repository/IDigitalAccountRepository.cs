using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Repository
{
    public interface IDigitalAccountRepository
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
        Task<DigitalAccountModel> InsertAsync(DigitalAccountModel digitalAccount);
        Task<DigitalAccountModel> GetDigitalAccountByNumberAndDigitAsync(int number, char digit);
    }
}
