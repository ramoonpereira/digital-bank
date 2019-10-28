using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Security.JWT.Handler
{
    public class AuthorizeOptions
    {
            public string Issuer { get; set; }
            public string Subject { get; set; }
            public string Audience { get; set; }
            public DateTime NotBefore => DateTime.UtcNow;

            /// <summary> 
            /// Momento da criação do Token 
            /// </summary> 
            public DateTime CreatedOn => DateTime.UtcNow;
            /// <summary> 
            /// Duração
            /// </summary> 
            public TimeSpan ValidFor { get; set; }
            /// <summary> 
            /// Expiração do Token 
            /// </summary> 
            public DateTime Expiration => CreatedOn.Add(ValidFor);
            /// <summary> 
            /// JWT ID 
            /// </summary> 
            public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());
            /// <summary> 
            /// Chave de Autenticação para gerar os tokens 
            /// </summary> 
            public SigningCredentials SigningCredentials { get; set; }

        }
}
