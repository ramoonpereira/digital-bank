using AutoMapper;
using DigitalBank.Api.Pub.Authenticate.Business.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Login;
using DigitalBank.Api.Pub.Authenticate.DTOs.v1.Requests;
using DigitalBank.Api.Pub.Authenticate.DTOs.v1.Responses;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Controllers.v1
{
    [Route("authenticate")]
    public class AuthenticateController : Controller
    {
        private IAuthenticateBusiness _authenticateBusiness;
        private IMapper _mapper;
        public AuthenticateController(IAuthenticateBusiness authenticateBusiness, IMapper mapper)
        {
            _authenticateBusiness = authenticateBusiness;
            _mapper = mapper;

        }

        /// <summary>
        /// Autentica o cliente
        /// </summary>
        /// <param name="login">Objeto de autenticação. O cliente poderá entrar com o e-mail cadastrado</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDTO login)
        {

            TokenModel token = await _authenticateBusiness.LoginAsync(_mapper.Map<Login>(login));
            TokenResponseDTO response = _mapper.Map<TokenResponseDTO>(token);
            return Ok(response);
        }
    }
}
