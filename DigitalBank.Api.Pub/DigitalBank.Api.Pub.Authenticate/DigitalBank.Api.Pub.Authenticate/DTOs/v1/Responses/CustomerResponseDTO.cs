using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.DTOs.v1.Responses
{
    public class CustomerResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
