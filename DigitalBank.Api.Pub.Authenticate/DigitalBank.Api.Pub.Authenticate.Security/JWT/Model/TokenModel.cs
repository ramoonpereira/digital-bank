using System;

namespace DigitalBank.Api.Pub.Authenticate.Security.JWT.Model
{
    public class TokenModel
    {
        public string Id { get; set; }
        public object User { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpiresIn { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
