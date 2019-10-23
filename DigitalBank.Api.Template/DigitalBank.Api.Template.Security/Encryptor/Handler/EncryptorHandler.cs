using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DigitalBank.Api.Template.Security.Encryptor.Handler
{
    public class EncryptorHandler
    {
        private IConfiguration _configuration;
        private SHA256 _encryptor;

        public EncryptorHandler(IConfiguration configuration) {
            _encryptor = SHA256.Create();
            _configuration = configuration;
        }


        /// <summary>
        /// Cria uma senha
        /// </summary>
        /// <param name="pass">Senha digitada pelo usuário</param>
        /// <returns>Verdadeiro ou Falso</returns>
        public string CreatePassword(string pass)
        {
            return EncryptPassword((pass + _configuration["Encryptor:Secret"]));
        }

        /// <summary>
        /// Compara duas senhas e valida se são iguais
        /// </summary>
        /// <param name="typedPassword">Senha digitada pelo usuário</param>
        /// <param name="savedPassword">Senha criptografada no banco</param>
        /// <returns>Verdadeiro ou Falso</returns>
        public bool CheckPassword(string typedPassword, string savedPassword)
        {
            return EncryptPassword((typedPassword + _configuration["Encryptor:Secret"])) == savedPassword;
        }

        /// <summary>
        /// Criptografa a senha
        /// </summary>
        /// <param name="password">System.String Senha</param>
        /// <returns>A senha criptografada</returns>
        private string EncryptPassword(string password)
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
    }
}
