using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.DTOs.v1.Responses
{
    public class DigitalAccountResponseDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numero
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Digito
        /// </summary>
        public char Digit { get; set; }

        /// <summary>
        /// Saldo
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Limite de valor por transação
        /// </summary>
        public decimal TransferLimitTransaction { get; set; }

        /// <summary>
        /// Limite de valor diario de transação
        /// </summary>
        public decimal TransferLimitTransactionDay { get; set; }

        /// <summary>
        /// Situação
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
