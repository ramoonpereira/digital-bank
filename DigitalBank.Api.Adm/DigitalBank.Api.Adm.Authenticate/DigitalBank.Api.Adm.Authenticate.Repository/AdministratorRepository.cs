using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using DigitalBank.Api.Adm.Authenticate.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Repository.DbContext
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private AppDbContext _appDbContext;
        public AdministratorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<AdministratorModel> GetAdministratorByEmailAsync(string email)
        {
            return Task.Run(() =>
            {
                return _appDbContext.Administrators.Where(c => c.Email.Equals(email)).FirstOrDefault();
            }
            );
        }
    }
}
