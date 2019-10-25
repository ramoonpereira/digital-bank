using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Interfaces
{
    public interface IDigitalAccountBusiness
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
        Task<DigitalAccountModel> InsertAsync(CustomerModel customer);
        Task<DigitalAccountModel> GenerateNewDigitalAccountNumberAndDigit(DigitalAccountModel digitalAccount);
        Task Authorize(string accessToken);
    }
}
