using AutoMapper;
using DigitalBank.Api.Adm.Transaction.Business.Interfaces;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Adm.Transaction.Business.Models.DigitalAccountTransaction;
using DigitalBank.Api.Adm.Transaction.Business.Pagination;
using DigitalBank.Api.Adm.Transaction.DTOs.v1.Responses;
using DigitalBank.Api.Adm.Transaction.Security.JWT.Model;
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

namespace DigitalBank.Api.Adm.Transaction.Controllers.v1
{
    [ApiController]
    [Route("transaction/v1")]
    public class TransactionController : Controller
    {
        private IDigitalAccountTransactionBusiness _digitalAccountTransactionBusiness;
        private IMapper _mapper;

        public TransactionController(IDigitalAccountTransactionBusiness digitalAccountTransactionBusiness, IMapper mapper)
        {
            _digitalAccountTransactionBusiness = digitalAccountTransactionBusiness;
            _mapper = mapper;

        }


        /// <summary>
        /// Busca uma transação da conta
        /// </summary>
        /// <param name="transactionId">Id da transação</param>
        /// <returns></returns>
        [HttpGet("{transactionId}")]
        [Authorize(Roles = "adm-transaction-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TransactionResponseDTO), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTransactionByIdAsync([Required]int transactionId)
        {
            DigitalAccountTransactionModel transaction = await _digitalAccountTransactionBusiness.GetByIdAsync(transactionId);
            TransactionResponseDTO response = _mapper.Map<TransactionResponseDTO>(transaction);

            return Ok(response);
        }

        /// <summary>
        /// Busca transações de uma conta digital por periodo
        /// </summary>
        /// <param name="digitalAccountId">Id da conta digital</param>
        /// <param name="startDate">Data Inicial - Default 30 dias</param>
        /// <param name="endDate">Data Final - Default Dia Atual</param>
        /// <param name="page">Pagina - Default 1</param>
        /// <param name="pageSize">Pagina - Default 10</param>
        /// <returns></returns>
        [HttpGet("{digitalAccountId}/transactions")]
        [Authorize(Roles = "adm-transaction-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PagedResultBase<TransactionResponseDTO>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllTransactionsByPeriodAsync([Required]int digitalAccountId, [FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate, [FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            PagedResultBase<DigitalAccountTransactionModel> transactions =
                await _digitalAccountTransactionBusiness.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate, page, pageSize);

            PagedResultBase<TransactionResponseDTO> response = _mapper.Map<PagedResultBase<TransactionResponseDTO>>(transactions);

            return Ok(response);
        }

        /// <summary>
        /// Busca todas transações por filtros
        /// </summary>
        /// <param name="startDate">Data Inicial - Default 30 dias</param>
        /// <param name="endDate">Data Final - Default Dia Atual</param>
        /// <param name="page">Pagina - Default 1</param>
        /// <param name="pageSize">Pagina - Default 10</param>
        /// <returns></returns>
        [HttpGet("filter")]
        [Authorize(Roles = "adm-transaction-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PagedResultBase<TransactionResponseDTO>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetFilterAsync([FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate, [FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            PagedResultBase<DigitalAccountTransactionModel> transactions =
                await _digitalAccountTransactionBusiness.GetFilterAsync(startDate, endDate, page, pageSize);

            PagedResultBase<TransactionResponseDTO> response = _mapper.Map<PagedResultBase<TransactionResponseDTO>>(transactions);

            return Ok(response);
        }
    }
}
