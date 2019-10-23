using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using DigitalBank.Api.Pub.Authenticate.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Repository.DbContext
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return Task.Run(() =>
            {
                return _appDbContext.Customers.Include(customer => customer.Permissions).Where(c => c.Email.Equals(email)).FirstOrDefault();
            }
            );
        }
    }
}
