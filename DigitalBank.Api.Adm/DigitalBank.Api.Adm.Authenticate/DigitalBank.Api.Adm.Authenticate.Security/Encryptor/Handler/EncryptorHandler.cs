using DigitalBank.Api.Adm.Authenticate.Security.Encryptor.Handler.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Security.Encryptor.Handler
{
    public class EncryptorHandler : IEncryptorHandler
    {
        private IConfiguration _configuration;
        private SHA256 _encryptor;
        private string _secret;

        public EncryptorHandler(IConfiguration configuration)
        {
            _encryptor = SHA256.Create();
            _configuration = configuration;
            _secret = _configuration["Security:Encryptor_Secret"];
        }


        public async Task<string> CreateEncryptPassword(string pass)
        {
            return await EncryptPassword((pass + _secret));
        }

        public async Task<bool> CheckPassword(string typedPassword, string savedPassword)
        {
            string encryptPass = await EncryptPassword((typedPassword + _secret));
            return encryptPass == savedPassword;
        }

        private Task<string> EncryptPassword(string password)
        {
            return Task.Run(() =>
            {
                var encodedPassword = Encoding.UTF8.GetBytes(password);
                var encryptedPassword = _encryptor.ComputeHash(encodedPassword);

                var sb = new StringBuilder();
                foreach (var caracter in encryptedPassword)
                {
                    sb.Append(caracter.ToString("X2"));
                }

                return sb.ToString();
            }
            );
        }
    }
}
