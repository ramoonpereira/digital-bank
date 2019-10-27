using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.Business.Repository
{
    public interface IDigitalAccountRepository
    {
        Task<DigitalAccountModel> GetDigitalAccountByCustomerIdAsync(int customerId);
        Task<DigitalAccountModel> GetByIdAsync(int customerId);
        Task<List<DigitalAccountModel>> GetAllAsync();
    }
}
