
using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Business.Interfaces
{
    public interface IAdministratorBusiness
    {
        Task<AdministratorModel> GetAdministratorByEmailAsync(string email);
    }
}
