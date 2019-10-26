using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.DTOs.v1.Requests
{
    public class TransactionRequestDTO
    {
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public TransactionOperationEnum Operation { get; set; }

        /// <summary>
        /// Conta que esta enviando a transação
        /// </summary>
        public DigitalAccountRequestDTO DigitalAccountSender { get; set; }

        /// <summary>
        /// Conta recebedora da transação
        /// </summary>
        public DigitalAccountRequestDTO DigitalAccountRecipient { get; set; }
    }
}
