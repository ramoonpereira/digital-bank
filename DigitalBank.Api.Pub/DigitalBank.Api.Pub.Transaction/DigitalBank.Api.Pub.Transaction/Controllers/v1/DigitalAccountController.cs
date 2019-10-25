using AutoMapper;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Models.Customer;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.DTOs.v1.Requests;
using DigitalBank.Api.Pub.Transaction.DTOs.v1.Responses;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.Controllers.v1
{
    [ApiController]
    [Route("digitalaccount/v1")]
    public class DigitalAccountController : Controller
    {
        private IDigitalAccountBusiness _digitalAccountBusiness;
        private IMapper _mapper;
        private string _accessToken;
        public DigitalAccountController(IDigitalAccountBusiness digitalAccountBusiness, IMapper mapper)
        {
            _digitalAccountBusiness = digitalAccountBusiness;
            _mapper = mapper;

        }

        /// <summary> 
        /// Recupera o Access token 
        /// </summary> 
        /// <param name="context"></param> 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
        }

        /// <summary>
        /// Efetua criação da conta digital
        /// </summary>
        /// <param name="digitalAccountRequest">Dados de criação da conta digital</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DigitalAccountResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateDigitalAccountAsync([FromBody]DigitalAccountRequestDTO digitalAccountRequest)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(digitalAccountRequest);
            DigitalAccountModel digitalAccount = await _digitalAccountBusiness.InsertAsync(customer);
            DigitalAccountResponseDTO response = _mapper.Map<DigitalAccountResponseDTO>(digitalAccount);

            return Ok(response);
        }

        /// <summary>
        /// Busca conta digital do cliente
        /// </summary>
        /// <param name="customerId">Id do cliente da conta digital</param>
        /// <returns></returns>
        [HttpGet("{customerId}/bycustomer")]
        [Authorize(Roles = "pub-digitalaccount-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DigitalAccountResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetDigitalAccountByCustomerAsync([Required]int customerId)
        {
            await _digitalAccountBusiness.Authorize(_accessToken);
            DigitalAccountModel digitalAccount = await _digitalAccountBusiness.GetDigitalAccountByCustomerIdAsync(customerId);
            DigitalAccountResponseDTO response = _mapper.Map<DigitalAccountResponseDTO>(digitalAccount);

            return Ok(response);
        }
    }
}
