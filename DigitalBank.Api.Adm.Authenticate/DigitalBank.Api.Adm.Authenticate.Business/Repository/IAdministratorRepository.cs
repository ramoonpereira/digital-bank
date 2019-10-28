using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Business.Repository
{
    public interface IAdministratorRepository
    {
        Task<AdministratorModel> GetAdministratorByEmailAsync(string email);
    }
}
