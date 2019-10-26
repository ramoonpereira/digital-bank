using AutoMapper;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
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
    [Route("transaction/v1")]
    public class TransactionController : Controller
    {
        private IDigitalAccountTransactionBusiness _digitalAccountTransactionBusiness;
        private IMapper _mapper;
        private string _accessToken;
        public TransactionController(IDigitalAccountTransactionBusiness digitalAccountTransactionBusiness, IMapper mapper)
        {
            _digitalAccountTransactionBusiness = digitalAccountTransactionBusiness;
            _mapper = mapper;

        }

        /// <summary> 
        /// Recupera o Access token 
        /// </summary> 
        /// <param name="context"></param> 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            if (!string.IsNullOrWhiteSpace(_accessToken))
                _digitalAccountTransactionBusiness.Authorize(_accessToken).GetAwaiter();
        }

        /// <summary>
        /// Efetua criação de uma transação de deposito
        /// </summary>
        /// <param name="transactionRequest">Dados de criação da transação</param>
        /// <returns></returns>
        [HttpPost("deposit")]
        [Authorize(Roles = "pub-transaction-c")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TransactionResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTransactionDepositAsync([FromBody]TransactionDepositRequestDTO transactionRequest)
        {
            DigitalAccountTransactionModel transaction = _mapper.Map<DigitalAccountTransactionModel>(transactionRequest);
            DigitalAccountTransactionModel transactionResponse = await _digitalAccountTransactionBusiness.CreateTransactionDepositAsync(transaction);
            TransactionResponseDTO response = _mapper.Map<TransactionResponseDTO>(transactionResponse);

            return Ok(response);
        }

        /// <summary>
        /// Efetua criação de uma transação de transferencia entre contas
        /// </summary>
        /// <param name="transactionRequest">Dados de criação da transação</param>
        /// <returns></returns>
        [HttpPost("transfer")]
        [Authorize(Roles = "pub-transaction-c")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TransactionResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTransactionTransferAsync([FromBody]TransactionTransferRequestDTO transactionRequest)
        {
            DigitalAccountTransactionModel transaction = _mapper.Map<DigitalAccountTransactionModel>(transactionRequest);
            DigitalAccountTransactionModel transactionResponse = await _digitalAccountTransactionBusiness.CreateTransactionTransferAsync(transaction);
            TransactionResponseDTO response = _mapper.Map<TransactionResponseDTO>(transactionResponse);

            return Ok(response);
        }

        /// <summary>
        /// Busca uma transação da conta
        /// </summary>
        /// <param name="transactionId">Id da transação</param>
        /// <returns></returns>
        [HttpGet("{transactionId}")]
        [Authorize(Roles = "pub-transaction-r")]
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
        /// <returns></returns>
        [HttpGet("{digitalAccountId}/transactions")]
        [Authorize(Roles = "pub-transaction-r")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<TransactionResponseDTO>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllTransactionsByPeriodAsync([Required]int digitalAccountId, [FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate)
        {
            List<DigitalAccountTransactionModel> transactions =
                await _digitalAccountTransactionBusiness.GetAllTransactionsByPeriodAsync(digitalAccountId, startDate, endDate);

            List<TransactionResponseDTO> response = _mapper.Map<List<TransactionResponseDTO>>(transactions);

            return Ok(response);
        }
    }
}
