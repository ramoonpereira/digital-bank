using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.DTOs.v1.Responses
{
    public class TransactionResponseDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Operação
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Situação
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Conta Recebedora
        /// </summary>
        public DigitalAccountResponseDTO DigitalAccount { get; set; }

        /// <summary>
        /// Conta Remetente
        /// </summary>
        public DigitalAccountResponseDTO DigitalAccountSender { get; set; }
    }
}
