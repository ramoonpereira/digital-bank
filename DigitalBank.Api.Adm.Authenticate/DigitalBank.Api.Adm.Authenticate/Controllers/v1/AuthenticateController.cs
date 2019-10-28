using AutoMapper;
using DigitalBank.Api.Adm.Authenticate.Business.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Login;
using DigitalBank.Api.Adm.Authenticate.DTOs.v1.Requests;
using DigitalBank.Api.Adm.Authenticate.DTOs.v1.Responses;
using DigitalBank.Api.Adm.Authenticate.Security.JWT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("authenticate/v1")]
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
        /// Autentica o administrador
        /// </summary>
        /// <param name="login">Objeto de autenticação. O administrador poderá entrar com o e-mail cadastrado</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TokenResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> LoginAsync([FromBody]LoginRequestDTO login)
        {
            TokenModel token = await _authenticateBusiness.LoginAsync(_mapper.Map<LoginModel>(login));
            TokenResponseDTO response = _mapper.Map<TokenResponseDTO>(token);

            return Ok(response);
        }
    }
}
