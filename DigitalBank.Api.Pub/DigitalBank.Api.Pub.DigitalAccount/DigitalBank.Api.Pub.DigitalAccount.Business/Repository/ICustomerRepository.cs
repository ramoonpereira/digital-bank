using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> InsertAsync(CustomerModel newCustomer);
    }
}
