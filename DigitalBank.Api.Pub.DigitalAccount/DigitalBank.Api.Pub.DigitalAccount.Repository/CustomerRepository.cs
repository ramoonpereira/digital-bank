using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CustomerModel> InsertAsync(CustomerModel newCustomer)
        {

            var customer = await _appDbContext.Customers.AddAsync(newCustomer);

            await _appDbContext.SaveChangesAsync();

            return customer.Entity;
        }

        public Task<CustomerModel> GetCustomerByEmailAsync(string email)
        {
            return Task.Run(() =>
            {
                return _appDbContext.Customers.Where(c => c.Email.Equals(email)).FirstOrDefault();
            });
        }

        public Task<CustomerModel> GetCustomerByDocumentAsync(long document)
        {
            return Task.Run(() =>
            {
                return _appDbContext.Customers.Where(c => c.Document.Equals(document)).FirstOrDefault();
            });
        }
    }
}
