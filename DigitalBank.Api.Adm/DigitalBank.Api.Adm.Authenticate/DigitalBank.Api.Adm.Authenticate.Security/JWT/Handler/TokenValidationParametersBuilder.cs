using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Api.Adm.Authenticate.Security.JWT.Handler
{
    /// <summary> 
    /// Classe auxiliar para instanciar a TokenValidationParameters 
    /// </summary> 
    public class TokenValidationParametersBuilder
    {
        private bool _ValidateIssuer;
        private string _ValidIssuer;
        private bool _ValidateAudience;
        private string _ValidAudience;
        private bool _ValidateIssuerSigningKey;
        private SecurityKey _IssuerSigningKey;
        private bool _RequireExpirationTime;
        private bool _ValidateLifetime;
        private TimeSpan _ClockSkew;

        /// <summary> 
        /// Instancia os parâmetros que serão usados na TokenValidation 
        /// </summary> 
        /// <param name="tokenOptions"></param> 
        /// <param name="signingKey"></param> 
        public TokenValidationParametersBuilder(IConfigurationSection tokenOptions, SymmetricSecurityKey signingKey)
        {
            _ValidateIssuer = false;
            _ValidIssuer = tokenOptions[nameof(AuthorizeOptions.Issuer)];
            _ValidateAudience = false;
            _ValidAudience = tokenOptions[nameof(AuthorizeOptions.Audience)];
            _ValidateIssuerSigningKey = true;
            _IssuerSigningKey = signingKey;
            _RequireExpirationTime = true;
            _ValidateLifetime = true;
            _ClockSkew = TimeSpan.Zero;
        }

        /// <summary> 
        /// Cria uma nova instância da TokenValidationParameters já configurada 
        /// </summary> 
        /// <returns></returns> 
        public TokenValidationParameters Build()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = _ValidateIssuer,
                ValidIssuer = _ValidIssuer,

                ValidateAudience = _ValidateAudience,
                ValidAudience = _ValidAudience,

                ValidateIssuerSigningKey = _ValidateIssuerSigningKey,
                IssuerSigningKey = _IssuerSigningKey,

                RequireExpirationTime = _RequireExpirationTime,
                ValidateLifetime = _ValidateLifetime,

                ClockSkew = _ClockSkew
            };
        }

    }
}
