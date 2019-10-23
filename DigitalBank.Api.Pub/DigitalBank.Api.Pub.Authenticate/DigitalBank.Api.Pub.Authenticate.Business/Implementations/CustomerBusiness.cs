using System.Threading.Tasks;
using DigitalBank.Api.Pub.Authenticate.Business.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using DigitalBank.Api.Pub.Authenticate.Business.Repository;

namespace DigitalBank.Api.Pub.Authenticate.Business.Implementations
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerRepository _customerRepository;
        public CustomerBusiness(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.GetCustomerByEmailAsync(email);
        }
    }
}
