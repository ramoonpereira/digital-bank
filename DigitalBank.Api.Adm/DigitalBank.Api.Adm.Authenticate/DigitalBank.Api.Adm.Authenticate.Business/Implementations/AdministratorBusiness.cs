using System.Threading.Tasks;
using DigitalBank.Api.Adm.Authenticate.Business.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using DigitalBank.Api.Adm.Authenticate.Business.Repository;

namespace DigitalBank.Api.Adm.Authenticate.Business.Implementations
{
    public class AdministratorBusiness : IAdministratorBusiness
    {
        private IAdministratorRepository _administratorRepository;
        public AdministratorBusiness(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        public async Task<AdministratorModel> GetAdministratorByEmailAsync(string email)
        {
            return await _administratorRepository.GetAdministratorByEmailAsync(email);
        }
    }
}
