using DigitalBank.Api.Pub.Transaction.Business.Implementations;
using DigitalBank.Api.Pub.Transaction.Business.Interfaces;
using DigitalBank.Api.Pub.Transaction.Business.Repository;
using DigitalBank.Api.Pub.Transaction.Security.JWT.Handler.Interfaces;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Api.Pub.Transaction.Business.Test
{
    public class DigitalAccountTransactionBusinessTest
    {
        private DigitalAccountTransactionBusiness _digitalAccountTransactionBusiness;
        private Mock<IDigitalAccountTransactionRepository> _digitalAccountTransactionRepositoryMock;
        private Mock<ITokenHandler> _tokenHandlerMock;
        private Mock<IDigitalAccountBusiness> _digitalAccountBusinessMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountTransactionRepositoryMock = new Mock<IDigitalAccountTransactionRepository>();
            _digitalAccountBusinessMock = new Mock<IDigitalAccountBusiness>();
            _tokenHandlerMock = new Mock<ITokenHandler>();

            _digitalAccountTransactionBusiness = new DigitalAccountTransactionBusiness(_digitalAccountTransactionRepositoryMock.Object,
                _digitalAccountBusinessMock.Object, _tokenHandlerMock.Object);
        }
    }
}
