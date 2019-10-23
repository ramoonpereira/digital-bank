using System;

namespace DigitalBank.Api.Template.Security.JWT.Model
{
    public class TokenModel
    {
        public string Id { get; set; }
        public object User { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
