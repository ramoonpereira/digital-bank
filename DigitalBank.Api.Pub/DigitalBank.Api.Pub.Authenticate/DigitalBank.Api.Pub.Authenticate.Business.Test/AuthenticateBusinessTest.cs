using DigitalBank.Api.Pub.Authenticate.Business.Implementations;
using DigitalBank.Api.Pub.Authenticate.Business.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Pub.Authenticate.Business.Test
{
    public class AuthenticateBusinessTest
    {
        private AuthenticateBusiness _authenticateBusiness;
        private Mock<ICustomerBusiness> _customerBusinessMock;
        private Mock<IPermissionBusiness> _permissionBusinessMock;
        private Mock<IEncryptorHandler> _encryptorHandlerMock;
        private Mock<ITokenHandler> _tokenHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _customerBusinessMock = new Mock<ICustomerBusiness>();
            _permissionBusinessMock = new Mock<IPermissionBusiness>();
            _encryptorHandlerMock = new Mock<IEncryptorHandler>();
            _tokenHandlerMock = new Mock<ITokenHandler>();

            _authenticateBusiness = new AuthenticateBusiness(
                _customerBusinessMock.Object,
                _encryptorHandlerMock.Object,
                _tokenHandlerMock.Object,
                _permissionBusinessMock.Object);
        }
    }
}
