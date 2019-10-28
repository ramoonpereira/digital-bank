
using DigitalBank.Api.Adm.Authenticate.Business.Models.Login;
using DigitalBank.Api.Adm.Authenticate.Security.JWT.Model;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Business.Interfaces
{
    public interface IAuthenticateBusiness
    {
        Task<TokenModel> LoginAsync(LoginModel login);
    }
}
