using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.DTOs.v1.Responses
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
        /// Situação
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
