﻿using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Repository
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
            }
            );
        }
    }
}
