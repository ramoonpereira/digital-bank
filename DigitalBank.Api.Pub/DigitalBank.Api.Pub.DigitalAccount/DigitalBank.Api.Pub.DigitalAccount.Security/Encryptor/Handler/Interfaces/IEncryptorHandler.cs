using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Security.Encryptor.Handler.Interfaces
{
    public interface IEncryptorHandler
    {
        Task<string> CreateEncryptPassword(string pass);
        Task<bool> CheckPassword(string typedPassword, string savedPassword);
    }
}
