
using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        Task<CustomerModel> GetCustomerByEmailAsync(string email);
    }
}
