using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.DTOs.v1.Responses
{
    public class TokenResponseDTO
    {
        /// <summary>
        /// Usuario do Token
        /// </summary>
        public CustomerResponseDTO User { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Tipo do Token
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Data Expiração
        /// </summary>
        public DateTime ExpiresIn { get; set; }

        /// <summary>
        /// Data Criação
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
