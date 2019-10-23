using DigitalBank.Api.Pub.Authenticate.Security.JWT.Model;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Security.JWT.Handler.Interfaces
{
    public interface ITokenHandler
    {
        Task<TokenModel> CreateJwtToken(dynamic user);
    }
}
