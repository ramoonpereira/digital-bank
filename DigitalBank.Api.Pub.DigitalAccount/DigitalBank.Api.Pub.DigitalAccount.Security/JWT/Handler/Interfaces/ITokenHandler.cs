﻿using DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Handler.Interfaces
{
    public interface ITokenHandler
    {
        Task<TokenModel> CreateJwtToken(dynamic user,string permissions);
        Task<JwtSecurityToken> DecodeJwtToken(string accessToken);
    }
}
