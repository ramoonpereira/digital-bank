using DigitalBank.Api.Adm.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.DigitalAccount.Business.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.Business.Interfaces
{
    public interface IDigitalAccountBusiness
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
        Task<DigitalAccountModel> GetByIdAsync(int id);
        Task<PagedResultBase<DigitalAccountModel>> GetAllAsync(int page, int pageSize);
    }
}
