using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces
{
    public interface IDigitalAccountBusiness
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
        Task<DigitalAccountModel> InsertAsync(CustomerModel customer);
        Task<DigitalAccountModel> GenerateNewDigitalAccountNumberAndDigit(DigitalAccountModel digitalAccount);
        Task Authorize(string accessToken);
    }
}
