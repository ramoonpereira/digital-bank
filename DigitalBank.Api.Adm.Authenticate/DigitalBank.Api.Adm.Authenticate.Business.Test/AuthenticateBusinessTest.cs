using DigitalBank.Api.Adm.Authenticate.Business.Implementations;
using DigitalBank.Api.Adm.Authenticate.Business.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Adm.Authenticate.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Adm.Authenticate.Business.Test
{
    public class AuthenticateBusinessTest
    {
        private AuthenticateBusiness _authenticateBusiness;
        private Mock<IAdministratorBusiness> _administratorBusinessMock;
        private Mock<IPermissionBusiness> _permissionBusinessMock;
        private Mock<IEncryptorHandler> _encryptorHandlerMock;
        private Mock<ITokenHandler> _tokenHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _administratorBusinessMock = new Mock<IAdministratorBusiness>();
            _permissionBusinessMock = new Mock<IPermissionBusiness>();
            _encryptorHandlerMock = new Mock<IEncryptorHandler>();
            _tokenHandlerMock = new Mock<ITokenHandler>();

            _authenticateBusiness = new AuthenticateBusiness(
                _administratorBusinessMock.Object,
                _encryptorHandlerMock.Object,
                _tokenHandlerMock.Object,
                _permissionBusinessMock.Object);
        }
    }
}
