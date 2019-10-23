using DigitalBank.Api.Template.Security.JWT.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DigitalBank.Api.Template.Security.JWT.Handler
{
    public class TokenHandler
    {
        private IConfiguration _configuration;
        private AuthorizeOptions _options;
        private JwtSecurityTokenHandler handler;

        /// <summary>
        /// 
        /// </summary>
        public TokenHandler(IOptions<AuthorizeOptions> options, IConfiguration configuration)
        {
            _options = options.Value;
            _configuration = configuration;
            handler = new JwtSecurityTokenHandler();
        }

        /// <summary>
        /// Cria o token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TokenModel> CreateJwtToken(dynamic user)
        {
            var identity = await GetIdentity(user);
            var claims = await CreateClaims(identity, user);
            var jwt = CreateJwtSecurityToken(claims);
            var token = handler.WriteToken(jwt);

            return new TokenModel
            {
                TokenType = "Bearer",
                AccessToken = token,
                ExpiresIn = (int)jwt.expires.TotalSeconds,
                CreatedDate = DateTime.Now,
                User = user
            };
        }

        /// <summary>
        /// Autentica o usuário e valida o acesso
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private Task<ClaimsIdentity> GetIdentity(dynamic user)
        {
            var identity = new ClaimsIdentity(
                new GenericIdentity(user.document),
                new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Document", user.Document),
                    new Claim("Email", user.Email)
                }
            );

            return Task.FromResult(identity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        private async Task<Claim[]> CreateClaims(ClaimsIdentity identity, dynamic user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
            };

            foreach (var item in identity.Claims)
            {
                claims.Add(item);
            }

            return claims.ToArray();
        }

        /// <summary>
        /// Cria o Token de Segurança JWT
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        private JwtSecurityToken CreateJwtSecurityToken(Claim[] claims)
        {
            var securityToken = new JwtSecurityToken(
                  issuer: _options.Issuer,
                  audience: _options.Audience,
                  claims: claims,
                  notBefore: _options.NotBefore,
                  expires: GenerateExperation(),
                  signingCredentials: _options.SigningCredentials
                );

            return securityToken;
        }

        private DateTime GenerateExperation()
        {
            return DateTime.UtcNow.Add(TimeSpan.FromHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"])));
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
