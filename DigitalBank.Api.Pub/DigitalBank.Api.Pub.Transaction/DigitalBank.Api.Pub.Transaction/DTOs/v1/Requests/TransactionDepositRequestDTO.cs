using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.DTOs.v1.Requests
{
    public class TransactionDepositRequestDTO
    {
        /// <summary>
        /// Valor
        /// </summary>
        [Required]
        [Range(1.00, Int32.MaxValue, ErrorMessage = "Valor deve ser maior ou igual a 1.00")]
        public decimal Value { get; set; }

        /// <summary>
        /// Conta que esta enviando a transação
        /// </summary>
        public DigitalAccountRequestDTO DigitalAccountSender { get; set; }

        /// <summary>
        /// Conta recebedora da transação
        /// </summary>
        [Required]
        public DigitalAccountRequestDTO DigitalAccountRecipient { get; set; }
    }
}
