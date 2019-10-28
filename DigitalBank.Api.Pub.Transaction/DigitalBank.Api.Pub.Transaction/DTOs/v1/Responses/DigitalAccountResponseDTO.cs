using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.DTOs.v1.Responses
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

    }
}
