using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.DTOs.v1.Responses
{
    public class TokenResponseDTO
    {
        public string Id { get; set; }
        public CustomerResponseDTO User { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpiresIn { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
