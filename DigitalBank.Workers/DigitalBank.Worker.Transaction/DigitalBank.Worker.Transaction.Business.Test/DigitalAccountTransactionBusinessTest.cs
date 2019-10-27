using DigitalBank.Worker.Transaction.Business.Implementations;
using DigitalBank.Worker.Transaction.Business.Interfaces;
using DigitalBank.Worker.Transaction.Business.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace DigitalBank.Worker.Transaction.Business.Test
{
    public class DigitalAccountTransactionBusinessTest
    {
        private DigitalAccountTransactionBusiness _digitalAccountTransactionBusiness;
        private Mock<IDigitalAccountTransactionRepository> _digitalAccountTransactionRepositoryMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IDigitalAccountBusiness> _digitalAccountBusinessMock;

        [SetUp]
        public void SetUp()
        {
            _digitalAccountTransactionRepositoryMock = new Mock<IDigitalAccountTransactionRepository>();
            _digitalAccountBusinessMock = new Mock<IDigitalAccountBusiness>();
            _configurationMock = new Mock<IConfiguration>();

            _digitalAccountTransactionBusiness = new DigitalAccountTransactionBusiness(_digitalAccountTransactionRepositoryMock.Object,
                _digitalAccountBusinessMock.Object, _configurationMock.Object);
        }
    }
}
