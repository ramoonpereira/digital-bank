using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Transaction.DTOs.v1.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class DigitalAccountRequestDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Informe um Id valido")]
        public int? Id { get; set; }

    }
}
