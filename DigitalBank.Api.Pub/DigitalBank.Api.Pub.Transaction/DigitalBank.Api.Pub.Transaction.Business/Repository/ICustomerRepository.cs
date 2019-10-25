using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> InsertAsync(CustomerModel newCustomer);
        Task<CustomerModel> GetCustomerByEmailAsync(string email);
    }
}
