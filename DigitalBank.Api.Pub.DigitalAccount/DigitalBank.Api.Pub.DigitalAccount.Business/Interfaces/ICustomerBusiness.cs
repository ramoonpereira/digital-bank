using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        Task<CustomerModel> InsertAsync(CustomerModel newCustomer);
    }
}
