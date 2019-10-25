using DigitalBank.Api.Pub.Transaction.Business.Implementations;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Pub.Transaction.Business.Test
{
    public class DigitalAccountBusinessTest
    {
        private DigitalAccountBusiness _digitalAccountBusiness;
        private Mock<ICustomerBusiness> _customerBusinessMock;
        private Mock<IDigitalAccountRepository> _digitalAccountRepositoryMock;
        private Mock<ITokenHandler> _tokenHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountRepositoryMock = new Mock<IDigitalAccountRepository>();
            _tokenHandlerMock = new Mock<ITokenHandler>();
            _customerBusinessMock = new Mock<ICustomerBusiness>();

            _digitalAccountBusiness = new DigitalAccountBusiness(
                _digitalAccountRepositoryMock.Object,
                _customerBusinessMock.Object,
                _tokenHandlerMock.Object);
        }
    }
}
