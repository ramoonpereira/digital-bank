using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Business.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
