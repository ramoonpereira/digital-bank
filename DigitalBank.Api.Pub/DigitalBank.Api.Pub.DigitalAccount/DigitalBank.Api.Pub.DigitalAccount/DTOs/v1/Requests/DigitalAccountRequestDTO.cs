using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.DigitalAccount.DTOs.v1.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class DigitalAccountRequestDTO
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Required]
        [StringLength(255,ErrorMessage = "{0} deve possuir entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string Name { get; set; }

        /// <summary>
        /// Email do cliente
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        /// <summary>
        /// Senha para acesso
        /// </summary>
        [Required]
        [StringLength(12, ErrorMessage = "{0} deve possuir entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string Password { get; set; }

        /// <summary>
        /// Telefone - (DD999999999)
        /// </summary>
        [Required]
        [MaxLength(11)]
        [MinLength(10)]
        public string Phone { get; set; }

        /// <summary>
        /// Data nascimento do cliente (2019-10-24)
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Documento Identidade - CPF (99999999999)
        /// </summary>
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string Document { get; set; }
    }
}
