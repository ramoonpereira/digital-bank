using AutoMapper;
using DigitalBank.Api.Adm.DigitalAccount.Business.Interfaces;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.DigitalAccount.Business.Pagination;
using DigitalBank.Api.Adm.DigitalAccount.DTOs.v1.Responses;
using DigitalBank.Api.Adm.DigitalAccount.Security.JWT.Model;
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

namespace DigitalBank.Api.Adm.DigitalAccount.Controllers.v1
{
    [ApiController]
    [Route("digitalaccount/v1")]
    public class DigitalAccountController : Controller
    {
        private IDigitalAccountBusiness _digitalAccountBusiness;
        private IMapper _mapper;
   
        public DigitalAccountController(IDigitalAccountBusiness digitalAccountBusiness, IMapper mapper)
        {
            _digitalAccountBusiness = digitalAccountBusiness;
            _mapper = mapper;

        }

        /// <summary>
        /// Busca conta digital do cliente
        /// </summary>
        /// <param name="customerId">Id do cliente da conta digital</param>
        /// <returns></returns>
        [HttpGet("{customerId}/bycustomer")]
        [Authorize(Roles = "adm-digitalaccount-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DigitalAccountResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetDigitalAccountByCustomerAsync([Required]int customerId)
        {
            DigitalAccountModel digitalAccount = await _digitalAccountBusiness.GetDigitalAccountByCustomerIdAsync(customerId);
            DigitalAccountResponseDTO response = _mapper.Map<DigitalAccountResponseDTO>(digitalAccount);

            return Ok(response);
        }

        /// <summary>
        /// Busca conta digital por id
        /// </summary>
        /// <param name="id">Id  da conta digital</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "adm-digitalaccount-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DigitalAccountResponseDTO), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetByIdAsync([Required]int id)
        {
            DigitalAccountModel digitalAccount = await _digitalAccountBusiness.GetByIdAsync(id);
            DigitalAccountResponseDTO response = _mapper.Map<DigitalAccountResponseDTO>(digitalAccount);

            return Ok(response);
        }


        /// <summary>
        /// Busca todas as contas digitais
        /// </summary>
        /// <returns></returns>
        /// <param name="page">Pagina - Default 1</param>
        /// <param name="pageSize">Pagina - Default 10</param>
        [HttpGet]
        [Authorize(Roles = "adm-digitalaccount-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PagedResultBase<DigitalAccountResponseDTO>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllAsync([FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            PagedResultBase<DigitalAccountModel> digitalAccounts = await _digitalAccountBusiness.GetAllAsync(page, pageSize);
            PagedResultBase<DigitalAccountResponseDTO> response = _mapper.Map<PagedResultBase<DigitalAccountResponseDTO>>(digitalAccounts);

            return Ok(response);
        }
    }
}
