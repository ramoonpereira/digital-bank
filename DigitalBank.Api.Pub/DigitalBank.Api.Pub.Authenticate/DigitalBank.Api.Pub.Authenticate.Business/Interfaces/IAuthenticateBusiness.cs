
using DigitalBank.Api.Pub.Authenticate.Business.Models.Login;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Model;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Business.Interfaces
{
    public interface IAuthenticateBusiness
    {
        Task<TokenModel> LoginAsync(LoginModel login);
    }
}
