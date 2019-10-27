using DigitalBank.Api.Adm.DigitalAccount.Security.JWT.Handler.Interfaces;
using DigitalBank.Api.Adm.DigitalAccount.Security.JWT.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.Security.JWT.Handler
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration _configuration;
        private AuthorizeOptions _options;
        private JwtSecurityTokenHandler _handler;

        /// <summary>
        /// 
        /// </summary>
        public TokenHandler(IOptions<AuthorizeOptions> options, IConfiguration configuration)
        {
            _options = options.Value;
            _configuration = configuration;
            _handler = new JwtSecurityTokenHandler();
            _options.ValidFor = TimeSpan.FromHours(Convert.ToDouble(_configuration["Security:JwtExpireHours"]));
        }

        /// <summary>
        /// Cria o token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TokenModel> CreateJwtToken(dynamic user, string permissions)
        {
            var identity = await GetIdentity(user, permissions);
            var claims = await CreateClaims(identity, user);
            var jwt = CreateJwtSecurityToken(claims);
            var token = _handler.WriteToken(jwt);

            return new TokenModel
            {
                TokenType = "Bearer",
                AccessToken = token,
                ExpiresIn = DateTime.Now.AddHours(_options.ValidFor.TotalHours),
                CreatedDate = DateTime.Now,
                User = user
            };
        }

        /// <summary>
        /// Decoda o token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<JwtSecurityToken> DecodeJwtToken(string accessToken)
        {
            var token = _handler.ReadJwtToken(accessToken);

            return Task.FromResult(token);
        }


        /// <summary>
        /// Autentica o usuário e valida o acesso
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private Task<ClaimsIdentity> GetIdentity(dynamic user, string permissions)
        {
            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Name, "Token"),
                new[] {
                    new Claim("Authorization", "Adm-DigitalBank"),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email)
                }
            );

            foreach (var role in permissions.Split(','))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

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
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_options.CreatedOn).ToString(), ClaimValueTypes.Integer64)
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
                  expires: _options.Expiration,
                  signingCredentials: _options.SigningCredentials
                );

            return securityToken;
        }

        private static long ToUnixEpochDate(DateTime date)
         => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
