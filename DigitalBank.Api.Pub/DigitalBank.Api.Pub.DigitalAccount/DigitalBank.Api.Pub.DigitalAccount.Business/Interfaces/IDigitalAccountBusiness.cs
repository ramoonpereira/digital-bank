using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces
{
    public interface IDigitalAccountBusiness
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
        Task Authorize(string accessToken);
    }
}
