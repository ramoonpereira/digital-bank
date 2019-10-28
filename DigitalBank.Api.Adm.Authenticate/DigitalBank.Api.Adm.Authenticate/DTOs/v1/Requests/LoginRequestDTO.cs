using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.DTOs.v1.Requests
{
    public class LoginRequestDTO
    {
        /// <summary>
        /// Email (ex: example@example.com)
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Required]
        [StringLength(12, ErrorMessage = "{0} deve possuir entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
