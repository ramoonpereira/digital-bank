using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        Task<CustomerModel> InsertAsync(CustomerModel newCustomer);
    }
}
