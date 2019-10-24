using DigitalBank.Api.Pub.DigitalAccount.Business.Implementations;
using DigitalBank.Api.Pub.DigitalAccount.Business.Repository;
using DigitalBank.Api.Pub.DigitalAccount.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Test
{
    public class DigitalAccountBusinessTest
    {
        private DigitalAccountBusiness _digitalAccountBusiness;
        private Mock<IDigitalAccountRepository> _digitalAccountRepositoryMock;
        private Mock<ITokenHandler> _tokenHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountRepositoryMock = new Mock<IDigitalAccountRepository>();
            _tokenHandlerMock = new Mock<ITokenHandler>();

            _digitalAccountBusiness = new DigitalAccountBusiness(
                _digitalAccountRepositoryMock.Object,
                _tokenHandlerMock.Object);
        }
    }
}
